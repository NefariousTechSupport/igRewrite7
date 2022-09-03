namespace igLibrary.Core
{
	public class igFileDescriptor
	{
		public igFilePath _path;
		public StreamHelper _stream;

		public igFileDescriptor(Stream data, string path, StreamHelper.Endianness endianness = StreamHelper.Endianness.Little)
		{
			_stream = new StreamHelper(data, endianness);
			_path = new igFilePath();
			_path.Set(path);
		}
	}
}