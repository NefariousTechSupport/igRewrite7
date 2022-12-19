using System.ComponentModel;

namespace igRewrite7
{
	public class Window : GameWindow
	{
		GUI gui;

		public Vector2 freecamLocal;

		igObjectDirectory rootDir;

		Entity e;

		CDrawable quad;

		bool cullEnabled;

		public Window(GameWindowSettings gws, NativeWindowSettings nws, string[] args) : base(gws, nws)
		{
			igFileContext.Singleton.Initialize(args[0]);
			igArchiveManager.Singleton.AddArchiveToPool(args[1]);
			rootDir = igObjectStreamManager.Singleton.Load(args[2]);

			//Initialize igCommandStreamDecoder
			//igCommandStreamDecoder.SetConstantBoolCommand = (loc, data) => GL.Uniform1((int)loc, data ? 1 : 0);
			//igCommandStreamDecoder.SetConstantIntCommand = (loc, data) => GL.Uniform1((int)loc, data);
			//igCommandStreamDecoder.SetConstantFloatCommand = (loc, data) => GL.Uniform1((int)loc, data);
			//igCommandStreamDecoder.SetConstantVec4fCommand = (loc, data) => GL.Uniform4((int)loc, Utils.ToOpenTKVector4(data));
			//igCommandStreamDecoder.SetConstantMatrix44fCommand = (loc, data) => { Matrix4 tkData = Utils.ToOpenTKMatrix4(data); GL.UniformMatrix4((int)loc, false, ref tkData); };
		}

		protected override void OnLoad()
		{
			base.OnLoad();
			
			GL.Enable(EnableCap.DepthTest);
			GL.Enable(EnableCap.Texture2D);

			MaterialManager.LoadMaterial("stdv;ulitf", "shaders/stdvsingle.glsl", "shaders/ulitf.glsl");
			MaterialManager.LoadMaterial("stdv;whitef", "shaders/stdvsingle.glsl", "shaders/whitef.glsl");

			Camera.Initialize();
			Camera.CreatePerspective(MathHelper.PiOver2, ClientSize.X / (float)ClientSize.Y);

			quad = new CDrawable();
			quad.SetVertexPositions(new float[]
			{
				-0.5f, -0.5f, -0.5f, 1,
				-0.5f, -0.5f, -0.5f, 1,
				-0.5f,  0.5f, -0.5f, 1,
				 0.5f,  0.5f, -0.5f, 1,
				 0.5f, -0.5f, -0.5f, 1,
				-0.5f, -0.5f,  0.5f, 1,
				-0.5f,  0.5f,  0.5f, 1,
				 0.5f,  0.5f,  0.5f, 1,
				 0.5f, -0.5f,  0.5f, 1,
			});
			quad.SetVertexTexCoords(new float[]
			{
				0, 0, 0, 1,
				0, 0, 0, 1,
				0, 0, 0, 1,
				0, 0, 0, 1,
				0, 0, 0, 1,
				0, 0, 0, 1,
				0, 0, 0, 1,
				0, 0, 0, 1,
				0, 0, 0, 1,
			});
			quad.SetVertexColours(new float[]
			{
				1, 1, 0, 1,
				1, 1, 0, 1,
				1, 1, 0, 1,
				1, 1, 0, 1,
				1, 1, 0, 1,
				1, 1, 0, 1,
				1, 1, 0, 1,
				1, 1, 0, 1,
				1, 1, 0, 1,
			});
			quad.SetIndices(new uint[]
			{
				5, 3, 1,
				3, 8, 4,
				7, 6, 8,
				2, 8, 6,
				1, 4, 2,
				5, 2, 6,
				5, 7, 3,
				3, 7, 8,
				7, 5, 6,
				2, 4, 8,
				1, 3, 4,
				5, 1, 2,
			});
			quad.SetMaterial(new Material(MaterialManager.materials["stdv;ulitf"]));

			igObjectStreamManager o = igObjectStreamManager.Singleton;

			AssetManager.Singleton.AddPackage("packages:/generated/UI/domains/juicedomain_permanent_pkg.igz");
			AssetManager.Singleton.AddPackage($"packages:/generated/packageXmls/permanent_{igCore.GetPlatformString(igCore.platform)}_pkg.igz");
			AssetManager.Singleton.AddPackage("packages:/generated/packageXmls/permanent_pkg.igz");
			AssetManager.Singleton.AddPackage("packages:/generated/packageXmls/permanent_2015_pkg.igz");
			AssetManager.Singleton.AddPackage("packages:/generated/packageXmls/permanentdeveloper_pkg.igz");
			AssetManager.Singleton.AddPackage(rootDir);

			//EntityManager.Singleton.Load(rootDir);
			//e.drawable = quad;
			//CEntity centity = EntityManager.Singleton.entities[0].instance as CEntity;
			//BoxCull firstEntity = EntityManager.Singleton.entities[0].cull as BoxCull;
			//e.transform.Position = EntityManager.Singleton.entities[0].transform.Position + (firstEntity._min + firstEntity._max) / 2;
			//e.transform.Scale = (firstEntity._max - firstEntity._min) * EntityManager.Singleton.entities[0].transform.Scale;
			//e = new Entity();
			//if(rootDir._objectList[0] is igModelInfo mi) e.drawable = new CDrawableList(mi);
			//else if(rootDir._objectList[1] is CGraphicsSkinInfo gsi) e.drawable = new CDrawableList(gsi);
			//else throw new NotImplementedException("unsupported object type");
			//e.name = "idk lol";
			//EntityManager.Singleton.loadedEntities.Add("e", new List<Entity>());
			//EntityManager.Singleton.loadedEntities["e"].Add(e);
			//EntityManager.Singleton.entities.Add(e);

			gui = new GUI(this);
		}

		protected override void OnRenderFrame(FrameEventArgs args)
		{
			base.OnRenderFrame(args);

			Camera.Update();

			//gui.RenderTo3D();

			//GL.ClearColor(0f, 0f, 0f, 1f);
			//GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

			//EntityManager.Singleton.Render();		//Not Instanced
			//AssetManager.Singleton.Render();		//Instanced

			//e.Draw();

			//GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);

			gui.FrameBegin(args.Time);

			gui.DrawSceneWindow();
			gui.DrawEntityWindow();
			gui.DrawInspector();

			gui.FrameEnd();

			SwapBuffers();
		}

		float moveSpeed = 50;

		protected override void OnUpdateFrame(FrameEventArgs args)
		{
			if(KeyboardState.IsKeyDown(Keys.Escape)) Close();

			float sensitivity = 0.01f;

			float mult = 1;

			if(KeyboardState.IsKeyDown(Keys.LeftShift)) mult = 10;
			moveSpeed += MouseState.ScrollDelta.Y;
			moveSpeed = MathHelper.Clamp(moveSpeed, 0, 1000);

			if(KeyboardState.IsKeyDown(Keys.W)) Camera.transform.Position -= Camera.transform.Forward * (float)args.Time * moveSpeed * mult;
			if(KeyboardState.IsKeyDown(Keys.A)) Camera.transform.Position -= Camera.transform.Right * (float)args.Time * moveSpeed * mult;
			if(KeyboardState.IsKeyDown(Keys.S)) Camera.transform.Position += Camera.transform.Forward * (float)args.Time * moveSpeed * mult;
			if(KeyboardState.IsKeyDown(Keys.D)) Camera.transform.Position += Camera.transform.Right * (float)args.Time * moveSpeed * mult;

			if(KeyboardState.IsKeyPressed(Keys.R)) EntityManager.Singleton.ignoreDraw = !EntityManager.Singleton.ignoreDraw;
			if(KeyboardState.IsKeyPressed(Keys.C))
			{
				cullEnabled = !cullEnabled;
				if(cullEnabled) GL.Enable(EnableCap.CullFace);
				else            GL.Disable(EnableCap.CullFace);
				Console.Write($"Cull Face set to {cullEnabled}");
			}
			if(KeyboardState.IsKeyPressed(Keys.Right))
			{
				while(true)
				{
					EntityManager.Singleton.loadedMap++;
					if(EntityManager.Singleton.loadedEntities.Count == EntityManager.Singleton.loadedMap)
					{
						EntityManager.Singleton.loadedMap = 0;
					}
					if(EntityManager.Singleton.loadedEntities.ElementAt((int)EntityManager.Singleton.loadedMap).Value.Count != 0) break;
				}
				Console.WriteLine($"Displaying {EntityManager.Singleton.loadedEntities.ElementAt((int)EntityManager.Singleton.loadedMap).Key}");
			}

			CursorGrabbed = MouseState.IsButtonDown(MouseButton.Right);


			if(CursorGrabbed)
			{
				freecamLocal += MouseState.Delta.Yx * sensitivity;

				freecamLocal.X = MathHelper.Clamp(freecamLocal.X, -MathHelper.Pi + 0.0001f, 0);

				//Camera.transform.rotation = Quaternion.FromAxisAngle(Vector3.UnitX, freecamLocal.X) * Quaternion.FromAxisAngle(Vector3.UnitY, freecamLocal.Y);
				Camera.transform.Rotation = Quaternion.FromAxisAngle(Vector3.UnitX, freecamLocal.X) * Quaternion.FromAxisAngle(Vector3.UnitZ, freecamLocal.Y);
			}
			else
			{
				CursorGrabbed = false;
				CursorVisible = true;
			}

			Title = $"igRewrite7 | {args.Time} seconds";

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