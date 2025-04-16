using Dictionary.DictionaryMenuMediator;
using Dictionary.Entitys;
using Dictionary.UserInput;

namespace Dictionary.ConsoleMenu.MenuOptions
{
    public class DictionaryMenu : IDictionaryMenuMediator
    {
        private readonly IConsoleMenuDisplayer _menuDisplayer;
        private readonly MainDictionary _mainDictionary;

        private const string _enterTheWord = "Введите слово: ";
        private const string _theTranslation = "Перевод вашего слова: ";
        private const string _addNewWord = "Ваше слово не найдено в словаре(\nЖелаете его добавить?";
        private string _userInput;

        public DictionaryMenu( IConsoleMenuDisplayer menuDisplayer, MainDictionary mainDictionary )
        {
            _menuDisplayer = menuDisplayer;
            _mainDictionary = mainDictionary;
        }
        public int RunMenu()
        {
            _menuDisplayer.UpdatePromt( PromtsAndOptions.DictionaryMenuPromt() );
            _menuDisplayer.UpdateOptions( PromtsAndOptions.DictionaryMenuOptions() );

            Console.Clear();
            Console.Write( _enterTheWord );
            _userInput = UserInputCorrector.GetInput();
            string newPromt = _enterTheWord + _userInput + "\n";

            if ( _mainDictionary.IsWordInDictionary( _userInput ) )
            {
                Console.WriteLine( $"{_theTranslation}{_mainDictionary.GetWord( _userInput )}" );
                newPromt = newPromt + _theTranslation + _mainDictionary.GetWord( _userInput ) + "\n";

                _menuDisplayer.UpdatePromt( newPromt );
            }
            else
            {
                newPromt = _addNewWord + "\n";
                _menuDisplayer.UpdatePromt( newPromt );
                _menuDisplayer.UpdateOptions( PromtsAndOptions.DictionaryNoWordMenuOptions() );
            }

            return _menuDisplayer.GetSelectedIndex();
        }

        public string TheWordOutOfDictionary()
        {
            return _userInput;
        }
    }
}
