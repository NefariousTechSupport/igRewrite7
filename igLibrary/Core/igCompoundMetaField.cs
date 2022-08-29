namespace igLibrary.Core
{
	public class igCompoundMetaField : igMetaField
	{
		public Type? _t = null;
		public igMetaFieldList _metaFields = new igMetaFieldList();

		public igCompoundMetaField()
		{
			this.UserInstantiate();
		}

		public override ushort Size(bool is64Bit)
		{
			if(is64Bit) return (ushort)_t.GetCustomAttribute<igStruct>()._size64;
			else        return (ushort)_t.GetCustomAttribute<igStruct>()._size32;
		}

		public override object? ReadRawMemory(igIGZ igz, bool is64Bit)
		{
			Console.WriteLine($"{GetType().Name} num fields: {this._metaFields._count}");

			object item = Activator.CreateInstance(_t);

			long objPos = igz._stream.BaseStream.Position;
			for(int j = 0; j < _metaFields._count; j++)
			{
				if(_metaFields[j]._version != igz._version && _metaFields[j]._version != 0xFF) continue;
				if(_metaFields[j]._overrides.Length > 0 && _metaFields[j]._overrides.Any(x => x == igz._platform)) continue;

				if(is64Bit) igz._stream.Seek(objPos + _metaFields[j]._offset64);
				else        igz._stream.Seek(objPos + _metaFields[j]._offset32);

				Console.WriteLine($"Processing {_t.Name} @ {objPos.ToString("X08")} in {igz._file._path}, metafield {_metaFields[j]._name} @ {igz._stream.BaseStream.Position.ToString("X08")} via {GetType().Name}");
				_t.GetField(_metaFields[j]._name).SetValue(item, _metaFields[j].ReadRawMemory(igz, is64Bit));
			}

			return item;
		}
		public virtual void UserInstantiate(){}
	}
}