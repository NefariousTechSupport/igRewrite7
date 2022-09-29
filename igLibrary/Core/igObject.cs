namespace igLibrary.Core
{
	[sizeofSize(0xFF, 0x08, 0x0C)]
	public class igObject
	{
		public virtual void ReadFields(igIGZ igz)
		{
			long objPos = igz._stream.BaseStream.Position;
			Type t = GetType();
			Console.WriteLine($"processing {t.Name} @ {objPos.ToString("X08")}");
			bool is64Bit = igCore.IsPlatform64Bit(igz._platform);
			FieldInfo[] fields = t.GetFields();
			System.Text.StringBuilder builder = new System.Text.StringBuilder(256);
			for(int i = 0; i < fields.Length; i++)
			{
				igField[] metafields = fields[i].GetCustomAttributes<igField>().ToArray();
				for(int j = 0; j < metafields.Length; j++)
				{
					if(metafields[j]._metaField._version != igz._version && metafields[j]._metaField._version != 0xFF) continue;
					if(metafields[j]._metaField._overrides.Length > 0 && !metafields[j]._metaField._overrides.Any(x => x == igz._platform)) continue;

					if(is64Bit) igz._stream.Seek(objPos + metafields[j]._metaField._offset64);
					else        igz._stream.Seek(objPos + metafields[j]._metaField._offset32);
					
					builder.Append("Processing ");
					builder.Append(t.Name);
					builder.Append(" @ ");
					builder.Append(objPos.ToString("X08"));
					builder.Append(" in ");
					builder.Append(igz._file._path._path);
					builder.Append(", metafield ");
					builder.Append(metafields[j]._metaField._name);

					Console.WriteLine(builder.ToString());

					builder.Clear();

					fields[i].SetValue(this, metafields[j].ReadIGZMemory(igz, is64Bit));

					break;
				}
			}
		}
		public virtual void WriteFields(igIGZSaver igz, StreamHelper sh)
		{
			long objPos = sh.BaseStream.Position;
			Type t = GetType();
			Console.WriteLine($"processing {t.Name} @ {objPos.ToString("X08")}");
			bool is64Bit = igCore.IsPlatform64Bit(igz._platform);
			FieldInfo[] fields = t.GetFields();
			System.Text.StringBuilder builder = new System.Text.StringBuilder(256);
			igz.WriteRawOffset(sh, igz.GetVtableIndex(GetType()));
			for(int i = 0; i < fields.Length; i++)
			{
				igField[] metafields = fields[i].GetCustomAttributes<igField>().ToArray();
				for(int j = 0; j < metafields.Length; j++)
				{
					if(metafields[j]._metaField._version != igz._version && metafields[j]._metaField._version != 0xFF) continue;
					if(metafields[j]._metaField._overrides.Length > 0 && !metafields[j]._metaField._overrides.Any(x => x == igz._platform)) continue;

					if(is64Bit) sh.Seek(objPos + metafields[j]._metaField._offset64);
					else        sh.Seek(objPos + metafields[j]._metaField._offset32);

					builder.Append("Processing ");
					builder.Append(t.Name);
					builder.Append(" @ ");
					builder.Append(objPos.ToString("X08"));
					builder.Append(" in ");
					//builder.Append(igz._file._path._path);
					builder.Append(", metafield ");
					builder.Append(metafields[j]._metaField._name);
					builder.Append(" @ ");
					builder.Append(sh.BaseStream.Position.ToString("X08"));
					Console.WriteLine(builder.ToString());
					builder.Clear();

					metafields[j].WriteIGZMemory(igz, sh, is64Bit, fields[i].GetValue(this));

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