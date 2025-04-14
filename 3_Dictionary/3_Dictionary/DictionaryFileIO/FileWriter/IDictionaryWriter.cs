namespace Dictionary.DictionaryFileIO.FileWriter
{
    public interface IDictionaryWriter
    {
        public void WriteDictionary( string filePath, Dictionary<string, string> txtDictionary );
    }
}
