namespace Dictionary.DictionaryFileIO.FileWriter
{
    public class DictionaryFileWriter : IDictionaryWriter
    {
        private readonly char _dictionarySeparator;

        public DictionaryFileWriter( char dictionarySeparator )
        {
            _dictionarySeparator = dictionarySeparator;
        }

        public void WriteDictionary( string filePath, Dictionary<string, string> txtDictionary )
        {
            using ( StreamWriter writer = new StreamWriter( filePath ) )
            {
                foreach ( var word in txtDictionary )
                {
                    string line1 = $"{word.Key}{_dictionarySeparator}{word.Value}";
                    writer.WriteLine( line1 );
                }
            }
        }
    }
}
