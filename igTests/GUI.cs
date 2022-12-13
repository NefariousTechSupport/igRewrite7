using ImGuiNET;

namespace igRewrite7
{
	public class GUI
	{
		ImGuiController controller;
		Window wnd;
		int gameWindowFBO;
		int gameWindowColourTexture;
		int gameWindowDepthTexture;
		int oldHeight = 0;
		int oldWidth = 0;
		bool initialized = false;

		Entity? selectedEntity = null;

		#region Low Level

		public GUI(Window wnd)
		{
			controller = new ImGuiController(wnd.ClientSize.X, wnd.ClientSize.Y);
			this.wnd = wnd;

			Resize();

			initialized = true;
		}

		public void Resize()
		{
			controller.WindowResized(wnd.ClientSize.X, wnd.ClientSize.Y);
		}

		private void Resize3DView(int width, int height)
		{
			if(width == oldWidth && height == oldHeight) return;

			oldWidth = width;
			oldHeight = height;

			if(initialized)
			{
				GL.DeleteFramebuffer(gameWindowFBO);
				GL.DeleteTexture(gameWindowColourTexture);
				GL.DeleteTexture(gameWindowDepthTexture);
			}

			gameWindowColourTexture = GL.GenTexture();
			GL.BindTexture(TextureTarget.Texture2D, gameWindowColourTexture);
			GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, width, height, 0, PixelFormat.Rgba, PixelType.UnsignedInt8888, IntPtr.Zero);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
			GL.BindTexture(TextureTarget.Texture2D, 0);

			gameWindowDepthTexture = GL.GenTexture();
			GL.BindTexture(TextureTarget.Texture2D, gameWindowDepthTexture);
			GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.DepthComponent, width, height, 0, PixelFormat.DepthComponent, PixelType.Float, IntPtr.Zero);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
			GL.BindTexture(TextureTarget.Texture2D, 0);

			gameWindowFBO = GL.GenFramebuffer();
			GL.BindFramebuffer(FramebufferTarget.Framebuffer, gameWindowFBO);
			GL.FramebufferTexture2D(FramebufferTarget.Framebuffer, FramebufferAttachment.ColorAttachment0, TextureTarget.Texture2D, gameWindowColourTexture, 0);
			GL.FramebufferTexture2D(FramebufferTarget.Framebuffer, FramebufferAttachment.DepthAttachment, TextureTarget.Texture2D, gameWindowDepthTexture, 0);

			if(GL.CheckFramebufferStatus(FramebufferTarget.Framebuffer) != FramebufferErrorCode.FramebufferComplete)
			{
				throw new Exception($"GameWindow FBO failed to initialize with error {GL.CheckFramebufferStatus(FramebufferTarget.Framebuffer).ToString()}");
			}
		}

		public void FrameBegin(double delta)
		{
			controller.Update(wnd, (float)delta);
		}

		public void RenderTo3D()
		{
			GL.BindFramebuffer(FramebufferTarget.Framebuffer, gameWindowFBO);
		}

		public void KeyPress(int c)
		{
			controller.PressChar((char)c);
		}

		public void FrameEnd()
		{
			controller.Render();
		}

		#endregion

		#region Windows

		public void DrawSceneWindow()
		{
			ImGui.Begin("View");

			System.Numerics.Vector2 viewSize = ImGui.GetWindowSize();
			//Console.WriteLine($"Size Of View is {viewSize}");

			Resize3DView((int)viewSize.X, (int)viewSize.Y);

			GL.BindFramebuffer(FramebufferTarget.Framebuffer, gameWindowFBO);

			GL.ClearColor(0f, 0f, 0f, 1f);
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

			GL.Viewport(0, 0, oldWidth, oldHeight);
			Camera.CreatePerspective(MathHelper.PiOver2, oldWidth / (float)oldHeight);

			EntityManager.Singleton.Render();

			GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
			GL.Viewport(0, 0, wnd.ClientSize.X, wnd.ClientSize.Y);

			ImGui.Image((IntPtr)gameWindowColourTexture, viewSize, System.Numerics.Vector2.UnitY, System.Numerics.Vector2.UnitX);

			ImGui.End();
		}

		public void DrawEntityWindow()
		{
			ImGui.Begin("Maps");
			for(int i = 0; i < EntityManager.Singleton.loadedEntities.Count; i++)
			{
				KeyValuePair<string, List<Entity>> map = EntityManager.Singleton.loadedEntities.ElementAt(i);
				if(map.Value.Count == 0) continue;
				if(ImGui.CollapsingHeader(map.Key))
				{
					for(int j = 0; j < map.Value.Count; j++)
					{
						ImGui.PushID($"{i}:{j}");

						if(ImGui.Button(map.Value[j].name))
						{
							Camera.transform.Position = map.Value[j].transform.Position;
							selectedEntity = map.Value[j];
						}

						ImGui.PopID();
					}
				}
			}
			ImGui.End();
		}

		public void DrawInspector()
		{
			ImGui.Begin("Inspector");
			if(selectedEntity != null)
			{
				ImGui.Text(selectedEntity.name);

				selectedEntity.transform.Position      = DrawVector3Field("Position", selectedEntity.transform.Position);
				selectedEntity.transform.EulerRotation = DrawVector3Field("Rotation", selectedEntity.transform.EulerRotation);
				selectedEntity.transform.Scale         = DrawVector3Field("Scale   ", selectedEntity.transform.Scale);
			}
			else
			{
				ImGui.Text("No Entity Selected");
			}
			ImGui.End();
		}

		#endregion

		#region Input Helpers

		private Vector3 DrawVector3Field(string label, OpenTK.Mathematics.Vector3 vec3)
		{
			System.Numerics.Vector3 nvec3 = Utils.ToNumericsVector3(vec3);
			if(DrawVector3Field(label, ref nvec3)) return Utils.ToOpenTKVector3(nvec3);
			else                                   return vec3;
		}
		private bool DrawVector3Field(string label, ref System.Numerics.Vector3 vec3)
		{
			ImGui.Text(label);
			ImGui.SameLine();
			ImGui.PushID($"{label}_InputFloat3");
			bool ret = ImGui.InputFloat3(string.Empty, ref vec3);
			ImGui.PopID();
			return ret;
		}

		#endregion
	}
}