using ImGuiNET;

namespace igRewrite7
{
	public class GUI
	{
		ImGuiController controller;
		Window wnd;

		Entity selectedEntity = null;

		public static int framebuffer;
		private static int framebufferTexture;
		bool raycast = false;

		public GUI(Window wnd)
		{
			controller = new ImGuiController(wnd.ClientSize.X, wnd.ClientSize.Y);
			this.wnd = wnd;
		}

		public void Resize()
		{
			controller.WindowResized(wnd.ClientSize.X, wnd.ClientSize.Y);
		}

		public static void InitializeFramebuffer()
		{
			framebuffer = GL.GenFramebuffer();
			GL.BindFramebuffer(FramebufferTarget.Framebuffer, framebuffer);
			framebufferTexture = GL.GenTexture();
			GL.BindTexture(TextureTarget.Texture2D, framebufferTexture);
			GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, 1280, 720, 0, PixelFormat.Rgb, PixelType.UnsignedShort, IntPtr.Zero);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
			GL.FramebufferTexture2D(FramebufferTarget.Framebuffer, FramebufferAttachment.ColorAttachment0, TextureTarget.Texture2D, framebufferTexture, 0);

			if(GL.CheckFramebufferStatus(FramebufferTarget.Framebuffer) != FramebufferErrorCode.FramebufferComplete)
			{
				throw new Exception("Framebuffer incomplete");
			}
			GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
		}

		public void FrameBegin(double delta)
		{
			controller.Update(wnd, (float)delta);
		}

		public void Tick()
		{
			if(wnd.KeyboardState.IsKeyPressed(Keys.P)) raycast = !raycast;

			if(raycast)
			{
				Vector2 mouse = wnd.MouseState.Position;
				Vector3 viewport = new Vector3(
					(2 * mouse.X) / wnd.ClientSize.X - 1,
					1 - (2 * mouse.Y) / wnd.ClientSize.Y,
					1
				);
				Vector4 homogeneousClip = new Vector4(viewport.X, viewport.Y, -1, 1);
				Vector4 eye = Matrix4.Invert(Matrix4.Transpose(Camera.ViewToClip)) * homogeneousClip;
				eye.Z = -1;
				eye.W = 0;
				Vector3 world = (Matrix4.Invert(Matrix4.Transpose(Camera.WorldToView)) * eye).Xyz;
				world.Normalize();
				string entityNames = string.Empty;
				ImGui.SetTooltip(entityNames);
			}
		}

		public void DrawEntityWindow()
		{
			ImGui.Begin("Regions", ImGuiWindowFlags.AlwaysAutoResize | ImGuiWindowFlags.AlwaysVerticalScrollbar);
			for(int i = 0; i < EntityManager.Singleton.entities.Count; i++)
			{
				ImGui.PushID($"{i}");
				if(ImGui.Button($"Entity {i}"))
				{
					Camera.transform.position = -EntityManager.Singleton.entities[i].transform.position;
					selectedEntity = EntityManager.Singleton.entities[i];
				}
				ImGui.PopID();
			}
			ImGui.End();
		}

		public void KeyPress(int c)
		{
			controller.PressChar((char)c);
		}

		private float test;
		private string strtest = string.Empty;

		private void ShowEntityInfo()
		{
			ImGui.Begin($"{selectedEntity.name} Properties");
			bool posChanged = false;
			System.Numerics.Vector3 position = Utils.ToNumericsVector3(selectedEntity.transform.position);
			if(ImGui.InputFloat3("Position: ", ref position)) posChanged = true;
			if(posChanged) selectedEntity.SetPosition(Utils.ToOpenTKVector3(position));
			ImGui.End();
			//ImGui.ShowDemoWindow();
		}

		public void FrameEnd()
		{
			controller.Render();
		}
	}
}