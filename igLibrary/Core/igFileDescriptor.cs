namespace igLibrary.Core
{
	public class igFileDescriptor
	{
		public string _path;
		public StreamHelper _stream;

		public igFileDescriptor(Stream data, string path, StreamHelper.Endianness endianness = StreamHelper.Endianness.Little)
		{
			_stream = new StreamHelper(data, endianness);
			_path = path;
		}
	}
}