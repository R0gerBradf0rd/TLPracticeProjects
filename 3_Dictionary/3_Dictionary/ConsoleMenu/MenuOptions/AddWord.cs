using Dictionary.ConsoleMenu.MenuRunner;
using Dictionary.DictionaryMenuMediator;
using Dictionary.Entitys;
using Dictionary.UserInput;

namespace Dictionary.ConsoleMenu.MenuOptions
{
    public class AddWord : IMenuRunner
    {
        private readonly IConsoleMenuMediator _menuMediator;
        private readonly string _word;
        private readonly MainDictionary _mainDictionary;

        private const string _enterTheTranslation = "Введите перевод: ";
        private const string _theWordAlreadyExist = "Данное слово уже есть в словаре!\n";

        public AddWord( IConsoleMenuMediator menuMediator, string word, MainDictionary mainDictionary )
        {
            _word = word;
            _mainDictionary = mainDictionary;
            _menuMediator = menuMediator;
        }

        private void RunMenu()
        {
            _menuMediator.SetTittle( TitelsAndOptions.AddWordMenuPromt() );
            _menuMediator.SetOptions( TitelsAndOptions.AddWordMenuOptions() );

            _menuMediator.ClearScreen();
            _menuMediator.WriteMessage( _enterTheTranslation );
            string userInput = UserInputCorrector.GetInput();

            if ( !_mainDictionary.IsWordInDictionary( userInput ) )
            {
                _mainDictionary.UpdateDictionary( _word, userInput );
            }
            else
            {
                _menuMediator.SetTittle( _theWordAlreadyExist );
            }
        }

        public int GetSelectedIndex()
        {
            RunMenu();
            return _menuMediator.GetSelectedIndex();
        }
    }
}
