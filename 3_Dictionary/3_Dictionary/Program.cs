using Dictionary.Entitys;

namespace Dictionary
{
    internal class Program
    {
        static void Main( string[] args )
        {
            var dictionary = new MainDictionary( "C:\\Users\\Svyat\\Desktop\\Рабочий стол\\Учеба\\TL\\TLPracticeProjects\\3_Dictionary\\3_Dictionary\\Dictionary.txt", ' ' );
            var dictionaryConsoleApp = new DictionaryConsoleApp( dictionary );

            dictionaryConsoleApp.Start();
        }
    }
}
