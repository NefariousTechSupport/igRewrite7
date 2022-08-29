namespace igLibrary.Gfx
{
	public class igVertexElementMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igVertexElement);

		public igVertexElementMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igVertexElement);
			igVertexElement.arkRegisterCompoundFields(this._metaFields);
		}
	}
}