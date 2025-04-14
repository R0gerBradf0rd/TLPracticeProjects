namespace Dictionary
{
    internal class Program
    {
        static void Main( string[] args )
        {
            var dictionaryManager = new DictionaryConsoleApp( "C:\\Users\\Svyat\\Desktop\\Рабочий стол\\Учеба\\TL\\TLPracticeProjects\\Dictionary\\3_Dictionary\\Dictionary.txt", ' ' );
            dictionaryManager.Start();
        }
    }
}
