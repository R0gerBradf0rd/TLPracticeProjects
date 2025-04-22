namespace Dictionary.DictionaryFileIO.FileWriter
{
    public class DictionaryTxtFileWriter : IDictionaryWriter
    {
        private readonly char _dictionarySeparator;

        public DictionaryTxtFileWriter( char dictionarySeparator )
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
