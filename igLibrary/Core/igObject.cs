using System.Collections;

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
		public virtual void WriteFields(igIGZSaver igz, int sectionIndex)
		{
			long objPos = igz._sections[sectionIndex]._stream.BaseStream.Position;

			Type t = GetType();
			Console.WriteLine($"processing {t.Name} @ {objPos.ToString("X08")}");

			bool is64Bit = igCore.IsPlatform64Bit(igz._platform);

			FieldInfo[] fields = t.GetFields();

			System.Text.StringBuilder builder = new System.Text.StringBuilder(256);

			igz._sections[sectionIndex]._stream.BaseStream.Write(new byte[GetSizeofSize(igz._version, igz._platform)]);

			igz._sections[sectionIndex]._stream.Seek(objPos);

			igz._sections[sectionIndex]._runtimeFields._vtables.Add(igz._sections[sectionIndex]._stream.Tell());
			igz.WriteRawOffset(igz._sections[sectionIndex]._stream, igz.GetVtableIndex(GetType()));

			for(int i = 0; i < fields.Length; i++)
			{
				if(fields[i].GetCustomAttribute<igNoWriteField>() != null) continue;

				igField[] metafields = fields[i].GetCustomAttributes<igField>().ToArray();
				for(int j = 0; j < metafields.Length; j++)
				{
					if(metafields[j]._metaField._version != igz._version && metafields[j]._metaField._version != 0xFF) continue;
					if(metafields[j]._metaField._overrides.Length > 0 && !metafields[j]._metaField._overrides.Any(x => x == igz._platform)) continue;

					if(is64Bit) igz._sections[sectionIndex]._stream.Seek(objPos + metafields[j]._metaField._offset64);
					else        igz._sections[sectionIndex]._stream.Seek(objPos + metafields[j]._metaField._offset32);

					builder.Append("Processing ");
					builder.Append(t.Name);
					builder.Append(" @ ");
					builder.Append(objPos.ToString("X08"));
					builder.Append(" in ");
					//builder.Append(igz._file._path._path);
					builder.Append(", metafield ");
					builder.Append(metafields[j]._metaField._name);
					builder.Append(" @ ");
					builder.Append(igz._sections[sectionIndex]._stream.BaseStream.Position.ToString("X08"));
					Console.WriteLine(builder.ToString());
					builder.Clear();

					metafields[j].WriteIGZMemory(igz, sectionIndex, is64Bit, fields[i].GetValue(this));

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
		public virtual igObject[] GetReferencedObjects()
		{
			List<igObject> references = new List<igObject>();
			FieldInfo[] fields = Utils.GetAllInstanceFields(GetType());
			for(uint i = 0; i < fields.Length; i++)
			{
				Type t = fields[i].FieldType;
				if(t.IsAssignableTo(typeof(igObject)))
				{
					igObject? obj = (igObject?)fields[i].GetValue(this);

					if(obj != null)
					{
						references.Add(obj);
					}
					continue;
				}
				if(t.IsGenericType && t.GetGenericTypeDefinition() == typeof(List<>))
				{
					if(t.GenericTypeArguments[0].IsAssignableTo(typeof(igObject)))
					{
						IList? objs = fields[i].GetValue(this) as IList;
						if(objs != null)
						{
							for(int j = 0; j < objs.Count; j++)
							{
								if(objs[j] != null)
								{
									references.Add((igObject)objs[j]);
								}
							}
						}
					}
				}
			}

			return references.ToArray();
		}
		public virtual ushort GetSizeofSize(uint version, IG_CORE_PLATFORM platform)
		{
			return sizeofSize.GetSizeOfType(GetType(), version, platform);
		}
	}
}