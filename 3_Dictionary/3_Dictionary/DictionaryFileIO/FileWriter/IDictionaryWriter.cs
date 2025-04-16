/// <summary>
/// Записывает слова из локального словаря в файл
/// </summary>

namespace Dictionary.DictionaryFileIO.FileWriter
{
    public interface IDictionaryWriter
    {
        /// <param name="filePath">Путь к файлу</param>
        /// <param name="txtDictionary">Локальный словарь</param>
        public void WriteDictionary( string filePath, Dictionary<string, string> txtDictionary );
    }
}
