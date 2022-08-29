namespace igLibrary.Gfx
{
	public class igNameMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igName);

		public igNameMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igName);
			igName.arkRegisterCompoundFields(this._metaFields);
		}
	}
}