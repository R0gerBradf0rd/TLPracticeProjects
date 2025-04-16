/// <summary>
/// Считывает слова из файла в локальный словарь
/// </summary>

namespace Dictionary.DictionaryFileIO.FilerReader
{
    public interface IDictionaryReader
    {
        /// <param name="dictionarySeparator"> Символ, между словом и пеерводом в словаре
        /// <param name="txtDictionary"> Локальный словарь, в который заносятся слова из файла</param>
        public void ReadDictionary( char dictionarySeparator, Dictionary<string, string> txtDictionary );
    }
}
