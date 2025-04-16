using Dictionary.DictionaryFileIO.FilerReader;
using Dictionary.DictionaryFileIO.FileWriter;

namespace Dictionary.Entitys
{
    public class MainDictionary
    {
        private readonly string _dictionaryFilePath;
        private readonly char _dictionarySeparator;
        private Dictionary<string, string> _dictionary = [];
        private Dictionary<string, string> _dictionaryReversed = [];

        public MainDictionary( string filePath, char sepatator )
        {
            _dictionaryFilePath = filePath;
            _dictionarySeparator = sepatator;
        }

        public void FillTheLocalDictionary()
        {
            IDictionaryReader fileReader = new DictionaryTxtFileReader( _dictionaryFilePath );
            fileReader.ReadDictionary( _dictionarySeparator, _dictionary );
            foreach ( var word in _dictionary )
            {
                _dictionaryReversed.Add( word.Value, word.Key );
            }
        }

        public void FillTheDictionary()
        {
            IDictionaryWriter fileWriter = new DictionaryTxtFileWriter( _dictionarySeparator );
            fileWriter.WriteDictionary( _dictionaryFilePath, _dictionary );
        }

        public void UpdateDictionary( string newWord, string newTranslation )
        {
            _dictionary[ newWord ] = newTranslation;
            _dictionaryReversed[ newTranslation ] = newWord;
        }

        public bool IsWordInDictionary( string word )
        {
            if ( _dictionary.ContainsKey( word ) )
                return true;
            else if ( _dictionaryReversed.ContainsKey( word ) )
                return true;
            return false;
        }

        public string GetWord( string word )
        {
            if ( _dictionary.ContainsKey( word ) )
                return _dictionary[ word ];
            else
                return _dictionaryReversed[ word ];
        }
    }
}
