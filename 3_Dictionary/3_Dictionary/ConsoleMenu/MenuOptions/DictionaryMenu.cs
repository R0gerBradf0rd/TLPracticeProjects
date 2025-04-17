using Dictionary.ConsoleMenu.MenuRunner;
using Dictionary.DictionaryMenuMediator;
using Dictionary.Entitys;
using Dictionary.UserInput;

namespace Dictionary.ConsoleMenu.MenuOptions
{
    public class DictionaryMenu : IDictionaryMenuRunner
    {
        private readonly IConsoleMenuMediator _menuMediator;
        private readonly MainDictionary _mainDictionary;

        private const string _enterTheWord = "Введите слово: ";
        private const string _theTranslation = "Перевод вашего слова: ";
        private const string _addNewWord = "Ваше слово не найдено в словаре(\nЖелаете его добавить?";
        private string _userInput;

        public DictionaryMenu( IConsoleMenuMediator menuMediator, MainDictionary mainDictionary )
        {
            _menuMediator = menuMediator;
            _mainDictionary = mainDictionary;
        }
        private void RunMenu()
        {
            _menuMediator.SetTittle( TitelsAndOptions.DictionaryMenuPromt() );
            _menuMediator.SetOptions( TitelsAndOptions.DictionaryMenuOptions() );

            _menuMediator.ClearScreen();
            _menuMediator.WriteMessage( _enterTheWord );
            _userInput = UserInputCorrector.GetInput();
            string newPromt = _enterTheWord + _userInput + "\n";

            if ( _mainDictionary.IsWordInDictionary( _userInput ) )
            {
                _menuMediator.WriteMessageInNewLine( $"{_theTranslation}{_mainDictionary.GetWord( _userInput )}" );
                newPromt = newPromt + _theTranslation + _mainDictionary.GetWord( _userInput ) + "\n";

                _menuMediator.SetTittle( newPromt );
            }
            else
            {
                newPromt = _addNewWord + "\n";
                _menuMediator.SetTittle( newPromt );
                _menuMediator.SetOptions( TitelsAndOptions.DictionaryNoWordMenuOptions() );
            }
        }

        public int GetSelectedIndex()
        {
            RunMenu();
            return _menuMediator.GetSelectedIndex();
        }

        public string TheWordOutOfDictionary()
        {
            return _userInput;
        }
    }
}
