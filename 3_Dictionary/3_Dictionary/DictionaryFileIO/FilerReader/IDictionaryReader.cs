namespace Dictionary.DictionaryFileIO.FilerReader
{
    public interface IDictionaryReader
    {
        public void ReadDictionary( char dictionarySeparator, Dictionary<string, string> txtDictionary, Dictionary<string, string> txtDictionaryReversed );
    }
}
