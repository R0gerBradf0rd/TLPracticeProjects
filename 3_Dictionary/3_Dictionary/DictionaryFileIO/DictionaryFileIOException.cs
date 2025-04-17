namespace Dictionary.DictionaryFileIO
{
    public class DictionaryFileIOException : Exception
    {
        public DictionaryFileIOException( string message, string filePath )
            : base( $"Error in {filePath}: {message}" )
        {
        }
    }
}
