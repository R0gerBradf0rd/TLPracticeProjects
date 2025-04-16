namespace Dictionary.DictionaryFileIO.FilerReader
{
    public class DictionaryTxtFileReader : IDictionaryReader
    {
        private readonly string _filePath;

        public DictionaryTxtFileReader( string filePath )
        {
            _filePath = filePath;
        }
        public void ReadDictionary( char dictionarySeparator, Dictionary<string, string> txtDictionary )
        {
            if ( !File.Exists( _filePath ) )
            {
                throw new Exception( "Неверно уазан путь к словрю" );
            }
            else
            {
                string[] lines = File.ReadAllLines( _filePath );

                foreach ( string line in lines )
                {
                    string[] words = line.Split( dictionarySeparator );
                    if ( txtDictionary.ContainsKey( words[ 0 ] ) )
                        throw new Exception( "Больше одного значения по одному ключу" );
                    else
                    {
                        if ( words.Length < 2 )
                            throw new Exception( "Неверный формат словоря" );
                        else
                            txtDictionary.Add( words[ 0 ].ToLower(), words[ 1 ].ToLower() );
                    }
                }
            }
        }
    }
}
