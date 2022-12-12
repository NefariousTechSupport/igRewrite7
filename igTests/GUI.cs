using ImGuiNET;

namespace igRewrite7
{
	public class GUI
	{
		ImGuiController controller;
		Window wnd;

		Entity selectedEntity = null;

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
				Vector3 world = (Matrix4.Invert(Matrix4.Transpose(Camera._worldToView)) * eye).Xyz;
				world.Normalize();
				string entityNames = string.Empty;
				ImGui.SetTooltip(entityNames);
			}
		}

		public void DrawEntityWindow()
		{
			ImGui.Begin("Maps", ImGuiWindowFlags.AlwaysAutoResize | ImGuiWindowFlags.AlwaysVerticalScrollbar);
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
							Camera.transform.Position = -map.Value[j].transform.Position;
							selectedEntity = map.Value[j];
						}

						ImGui.PopID();
					}
				}
			}
			ImGui.End();

			if(selectedEntity != null)
			{
				ShowEntityInfo();
			}
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
			bool rotChanged = false;
			bool scaleChanged = false;
			System.Numerics.Vector3 position = Utils.ToNumericsVector3(selectedEntity.transform.Position);
			System.Numerics.Vector3 rotation = Utils.ToNumericsVector3(selectedEntity.transform.EulerRotation);
			System.Numerics.Vector3 scale = Utils.ToNumericsVector3(selectedEntity.transform.Scale);
			if(ImGui.InputFloat3("Position: ", ref position)) posChanged = true;
			if(ImGui.InputFloat3("Rotation: ", ref rotation)) rotChanged = true;
			if(ImGui.InputFloat3("Scale: ", ref scale)) scaleChanged = true;
			if(posChanged) selectedEntity.transform.Position = Utils.ToOpenTKVector3(position);
			if(rotChanged) selectedEntity.transform.EulerRotation = Utils.ToOpenTKVector3(rotation);
			if(scaleChanged) selectedEntity.transform.Scale = Utils.ToOpenTKVector3(scale);
			ImGui.End();
			//ImGui.ShowDemoWindow();
		}

		public void FrameEnd()
		{
			controller.Render();
		}
	}
}