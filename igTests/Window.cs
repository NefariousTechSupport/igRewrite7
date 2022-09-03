using System.ComponentModel;

namespace igRewrite7
{
	public class Window : GameWindow
	{
		GUI gui;

		public Vector2 freecamLocal;

		igObjectDirectory rootDir;

		Entity e;

		public Window(GameWindowSettings gws, NativeWindowSettings nws, string[] args) : base(gws, nws)
		{
			igFileContext.Singleton.Initialize(args[0]);
			igArchiveManager.Singleton.AddArchiveToPool(args[1]);
			rootDir = igObjectStreamManager.Singleton.Load(args[2]);
		}

		protected override void OnLoad()
		{
			base.OnLoad();
			
			GL.Enable(EnableCap.DepthTest);
			GL.Enable(EnableCap.Texture2D);
			//GL.Enable(EnableCap.StencilTest);
			//GL.Enable(EnableCap.CullFace);
			//GL.Enable(EnableCap.Blend);
			//GL.BlendFuncSeparate(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha, BlendingFactorSrc.One, BlendingFactorDest.Zero);

			MaterialManager.LoadMaterial("stdv;ulitf", "shaders/stdvsingle.glsl", "shaders/ulitf.glsl");
			MaterialManager.LoadMaterial("stdv;whitef", "shaders/stdvsingle.glsl", "shaders/whitef.glsl");

			Camera.CreatePerspective(MathHelper.PiOver2, ClientSize.X / (float)ClientSize.Y);

			e = new Entity();
			e.transform = new Transform();
			if(rootDir._objectList[0] is igModelInfo mi) e.drawable = new CDrawableListList(mi);
			else if(rootDir._objectList[1] is CGraphicsSkinInfo gsi) e.drawable = new CDrawableListList(gsi);
			e.name = "idk lol";

			gui = new GUI(this);
		}

		protected override void OnRenderFrame(FrameEventArgs args)
		{
			base.OnRenderFrame(args);

			GL.ClearColor(0.1f, 0.1f, 0.1f, 0);
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

			gui.FrameBegin(args.Time);

			EntityManager.Singleton.Render();

			e.Draw();

			gui.Tick();

			gui.FrameEnd();

			SwapBuffers();
		}

		float moveSpeed = 5;

		protected override void OnUpdateFrame(FrameEventArgs args)
		{
			if(KeyboardState.IsKeyDown(Keys.Escape)) Close();

			float sensitivity = 0.01f;

			float mult = 1;

			if(KeyboardState.IsKeyDown(Keys.LeftShift)) mult = 10;
			moveSpeed += MouseState.ScrollDelta.Y;
			moveSpeed = MathHelper.Clamp(moveSpeed, 0, 1000);

			if(KeyboardState.IsKeyDown(Keys.W)) Camera.transform.position += Camera.transform.Forward * (float)args.Time * moveSpeed * mult;
			if(KeyboardState.IsKeyDown(Keys.A)) Camera.transform.position += Camera.transform.Right * (float)args.Time * moveSpeed * mult;
			if(KeyboardState.IsKeyDown(Keys.S)) Camera.transform.position -= Camera.transform.Forward * (float)args.Time * moveSpeed * mult;
			if(KeyboardState.IsKeyDown(Keys.D)) Camera.transform.position -= Camera.transform.Right * (float)args.Time * moveSpeed * mult;

			CursorGrabbed = MouseState.IsButtonDown(MouseButton.Right);


			if(CursorGrabbed)
			{
				freecamLocal += MouseState.Delta.Yx * sensitivity;

				freecamLocal.X = MathHelper.Clamp(freecamLocal.X, -MathHelper.PiOver2 + 0.0001f, MathHelper.PiOver2 - 0.0001f);

				Camera.transform.rotation = Quaternion.FromAxisAngle(Vector3.UnitX, freecamLocal.X) * Quaternion.FromAxisAngle(Vector3.UnitY, freecamLocal.Y);
			}
			else
			{
				CursorGrabbed = false;
				CursorVisible = true;
			}

			Title = $"igRewrite7 | {1 / args.Time}";

			base.OnUpdateFrame(args);
		}

		protected override void OnTextInput(TextInputEventArgs e)
		{
			base.OnTextInput(e);
			
			gui.KeyPress(e.Unicode);
		}

		protected override void OnResize(ResizeEventArgs e)
		{
			base.OnResize(e);

			GL.Viewport(0, 0, ClientSize.X, ClientSize.Y);
			Camera.CreatePerspective(MathHelper.PiOver2, ClientSize.X / (float)ClientSize.Y);
			gui.Resize();
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);
		}
	}
}