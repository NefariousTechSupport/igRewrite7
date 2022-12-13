namespace igRewrite7
{
	public static class Camera
	{
		public static Transform transform = new Transform();

		public static Matrix4 _worldToView { get; private set; }
		public static Matrix4 ViewToClip;
		public static Frustum _viewFrustum { get; private set; }

		private static float _zNear = 10;
		private static float _zFar = 1000000;
		private static float _aspect;
		public static float _fovY;

		public static void Initialize()
		{
			_viewFrustum = new Frustum();
		}
		public static void CreatePerspective(float fov, float aspect)
		{
			_fovY = fov;
			_aspect = aspect;
			ViewToClip = Matrix4.CreatePerspectiveFieldOfView(_fovY, _aspect, _zNear, _zFar);
		}
		public static void Update()
		{
			UpdateModel();
			UpdateFrustum();
		}
		private static void UpdateModel()
		{
			_worldToView = Matrix4.CreateTranslation(-transform.Position) * Matrix4.CreateFromQuaternion(transform.Rotation);
		}
		private static void UpdateFrustum()
		{
			float tang = (float)Math.Tan(_fovY * 0.5f);

			float hNear = _zNear * tang;
			float wNear = hNear * _aspect;

			float hFar = _zFar * tang;
			float wFar = hFar * _aspect;

			Vector3 right = transform.Right;
			Vector3 up = transform.Up;
			Vector3 forward = transform.Forward;
			Vector3 p = transform.Position;

			Vector3 forwardMultFar = forward * _zFar;
			float halfWFar = wFar;
			float halfHFar = hFar;

			//Near
			_viewFrustum._planes[0] = new Frustum.Plane( forward, p + _zNear * forward);
			//Far
			_viewFrustum._planes[1] = new Frustum.Plane(-forward, p + forwardMultFar);
			//Right
			_viewFrustum._planes[2] = new Frustum.Plane( Vector3.Cross(up, forwardMultFar + right * halfWFar), p);
			//Left
			_viewFrustum._planes[3] = new Frustum.Plane( Vector3.Cross(forwardMultFar - right * halfWFar, up), p);
			//Top
			_viewFrustum._planes[4] = new Frustum.Plane( Vector3.Cross(right, forwardMultFar - up * halfHFar), p);
			//Bottom
			_viewFrustum._planes[5] = new Frustum.Plane( Vector3.Cross(forwardMultFar + up * halfHFar, right), p);
		}
	}

	public struct Frustum
	{
		public struct Plane
		{
			public Vector3 _normal;
			public Vector3 _point;

			public Plane(Vector3 normal, Vector3 point)
			{
				_normal = Vector3.Normalize(normal);
				_point = point;
			}
		}

		//0: far
		//1: near
		//2: right
		//3: left
		//4: top
		//5: bottom
		public Plane[] _planes = new Plane[6];

		public Frustum(){}
	}

}