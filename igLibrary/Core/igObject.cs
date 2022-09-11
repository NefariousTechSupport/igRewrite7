namespace igLibrary.Core
{
	public class igObject
	{
		public virtual void ReadFields(igIGZ igz)
		{
			long objPos = igz._stream.BaseStream.Position;
			Console.WriteLine($"processing {GetType().Name} @ {objPos.ToString("X08")}");
			bool is64Bit = igCore.IsPlatform64Bit(igz._platform);
			FieldInfo[] fields = GetType().GetFields();
			for(int i = 0; i < fields.Length; i++)
			{
				igField[] metafields = fields[i].GetCustomAttributes<igField>().ToArray();
				for(int j = 0; j < metafields.Length; j++)
				{
					if(metafields[j]._metaField._version != igz._version && metafields[j]._metaField._version != 0xFF) continue;
					if(metafields[j]._metaField._overrides.Length > 0 && metafields[j]._metaField._overrides.Any(x => x == igz._platform)) continue;

					if(is64Bit) igz._stream.Seek(objPos + metafields[j]._metaField._offset64);
					else        igz._stream.Seek(objPos + metafields[j]._metaField._offset32);

					Console.WriteLine($"Processing {GetType().Name} @ {objPos.ToString("X08")} in {igz._file._path._path}, metafield {metafields[j]._metaField._name} @ {igz._stream.BaseStream.Position.ToString("X08")}");
					fields[i].SetValue(this, metafields[j].ReadIGZMemory(igz, is64Bit));

					break;
				}
			}
		}
		public T ShallowCopy<T>() where T : igObject, new()
		{
			FieldInfo[] fields = GetType().GetFields();
			T copy = new T();
			for(int i = 0; i < fields.Length; i++)
			{
				fields[i].SetValue(copy, fields[i].GetValue(this));
			}
			return copy;
		}
	}
}