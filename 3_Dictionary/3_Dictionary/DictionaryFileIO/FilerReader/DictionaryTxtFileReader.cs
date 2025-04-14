namespace Dictionary.DictionaryFileIO.FilerReader
{
    public class DictionaryTxtFileReader : IDictionaryReader
    {
        private readonly string _filePath;

        public DictionaryTxtFileReader( string filePath )
        {
            _filePath = filePath;
        }
        public void ReadDictionary( char dictionarySeparator, Dictionary<string, string> txtDictionary, Dictionary<string, string> txtDictionaryReversed )
        {
            string[] lines = File.ReadAllLines( _filePath );

            foreach ( string line in lines )
            {
                string[] words = line.Split( dictionarySeparator );
                if ( !txtDictionary.ContainsKey( words[ 0 ] ) )
                {
                    txtDictionary.Add( words[ 0 ], words[ 1 ] );
                    txtDictionaryReversed.Add( words[ 1 ], words[ 0 ] );
                }
                else continue;
            }
        }
    }
}
