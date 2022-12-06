namespace igRewrite7
{
	public class Transform
	{
		public Vector3 Position
		{
			get => _position;
			set
			{
				_position = value;
				UpdateM();
			}
		}
		public Quaternion Rotation
		{
			get => _quatRotation;
			set
			{
				Quaternion.ToEulerAngles(value, out _eulerRotation);
				_quatRotation = value;
				UpdateM();
			}
		}
		public Vector3 EulerRotation
		{
			get => _eulerRotation;
			set
			{
				_eulerRotation = value;
				_quatRotation = Quaternion.FromAxisAngle(Vector3.UnitZ, _eulerRotation.Z) * Quaternion.FromAxisAngle(Vector3.UnitY, _eulerRotation.Y) * Quaternion.FromAxisAngle(Vector3.UnitX, _eulerRotation.X);
				UpdateM();
			}
		}
		public Vector3 Scale
		{
			get => _scale;
			set
			{
				_scale = value;
				UpdateM();
			}
		}

		public Vector3 Forward => Quaternion.Invert(_quatRotation) * Vector3.UnitZ;
		public Vector3 Right => Quaternion.Invert(_quatRotation) * Vector3.UnitX;
		public Vector3 Up => Quaternion.Invert(_quatRotation) * Vector3.UnitY;

		private Vector3 _position;
		private Vector3 _eulerRotation;
		private Quaternion _quatRotation;
		private Vector3 _scale;

		public Matrix4 _m { get; private set; }

		public Transform()
		{
			_position = Vector3.Zero;
			_quatRotation = Quaternion.Identity;
			_eulerRotation = Vector3.Zero;
			_scale = Vector3.Zero;
			UpdateM();
		}
		public Transform(Vector3 position, Vector3 eulerRotation, Vector3 scale)
		{
			_position = position;
			_scale = scale;
			EulerRotation = eulerRotation;	//Also calls UpdateM
		}
		private void UpdateM()
		{
			_m = Matrix4.CreateScale(_scale) * Matrix4.CreateFromQuaternion(_quatRotation) * Matrix4.CreateTranslation(_position);
		}
	}
}