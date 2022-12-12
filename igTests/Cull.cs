namespace igRewrite7
{
	public class Cull
	{
		public virtual bool DoFrustumCull() => false;
	}
	public class BoxCull : Cull
	{
		public Vector3 _min;
		public Vector3 _max;
		public Transform _t;
		private Vector3[] _points;

		public BoxCull(Transform t, Vector3 min, Vector3 max)
		{
			_min = min;
			_max = max;
			_t = t;
			_points = new Vector3[8];
		}

		public override bool DoFrustumCull()
		{
			Frustum frust = Camera._viewFrustum;

			Vector3 delta = _max - _min;
			//_points[0] = _t.Position + Quaternion.Invert(_t.Rotation) * (_t.Scale * (_min));
			//_points[1] = _t.Position + Quaternion.Invert(_t.Rotation) * (_t.Scale * (_min + Vector3.UnitX * delta.X));
			//_points[2] = _t.Position + Quaternion.Invert(_t.Rotation) * (_t.Scale * (_min + Vector3.UnitY * delta.Y));
			//_points[3] = _t.Position + Quaternion.Invert(_t.Rotation) * (_t.Scale * (_min + Vector3.UnitZ * delta.Z));
			//_points[4] = _t.Position + Quaternion.Invert(_t.Rotation) * (_t.Scale * (_max - Vector3.UnitX * delta.X));
			//_points[5] = _t.Position + Quaternion.Invert(_t.Rotation) * (_t.Scale * (_max - Vector3.UnitY * delta.Y));
			//_points[6] = _t.Position + Quaternion.Invert(_t.Rotation) * (_t.Scale * (_max - Vector3.UnitZ * delta.Z));
			//_points[7] = _t.Position + Quaternion.Invert(_t.Rotation) * (_t.Scale * (_max));

			_points[0] = _t.Position + _t.Scale * (_min);
			_points[1] = _t.Position + _t.Scale * (_min + Vector3.UnitX * delta.X);
			_points[2] = _t.Position + _t.Scale * (_min + Vector3.UnitY * delta.Y);
			_points[3] = _t.Position + _t.Scale * (_min + Vector3.UnitZ * delta.Z);
			_points[4] = _t.Position + _t.Scale * (_max - Vector3.UnitX * delta.X);
			_points[5] = _t.Position + _t.Scale * (_max - Vector3.UnitY * delta.Y);
			_points[6] = _t.Position + _t.Scale * (_max - Vector3.UnitZ * delta.Z);
			_points[7] = _t.Position + _t.Scale * (_max);

			for(uint i = 0; i < frust._planes.Length; i++)
			{
				int pointsIn = 0;
				for(uint j = 0; j < _points.Length; j++)
				{
					float dist = Vector3.Dot(frust._planes[i]._normal, _points[j] - frust._planes[i]._point);
					if(dist >= 0) pointsIn++;
				}
				if(pointsIn == 0) return true;
			}
			return false;
		}
	}
}