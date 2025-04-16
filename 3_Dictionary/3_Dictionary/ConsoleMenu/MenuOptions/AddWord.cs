using System.Collections.Generic;
using Dictionary.DictionaryMenuMediator;
using Dictionary.Entitys;
using Dictionary.UserInput;

namespace Dictionary.ConsoleMenu.MenuOptions
{
    public class AddWord : IMenuMediator
    {
        private readonly IConsoleMenuDisplayer _menuDisplayer;
        private readonly string _word;
        private readonly MainDictionary _mainDictionary;

        private const string _enterTheTranslation = "Введите перевод: ";
        private const string _theWordAlreadyExist = "Данное слово уже есть в словаре!\n";

        public AddWord( IConsoleMenuDisplayer menuDisplayer, string word, MainDictionary mainDictionary )
        {
            _word = word;
            _mainDictionary = mainDictionary;
            _menuDisplayer = menuDisplayer;
        }
        public int RunMenu()
        {
            _menuDisplayer.UpdatePromt( PromtsAndOptions.AddWordMenuPromt() );
            _menuDisplayer.UpdateOptions( PromtsAndOptions.AddWordMenuOptions() );

            Console.Clear();
            Console.Write( _enterTheTranslation );
            string userInput = UserInputCorrector.GetInput();

            if ( !_mainDictionary.IsWordInDictionary( userInput ) )
            {
                _mainDictionary.UpdateDictionary( _word, userInput );
            }
            else
            {
                _menuDisplayer.UpdatePromt( _theWordAlreadyExist );
            }

            return _menuDisplayer.GetSelectedIndex();
        }
    }
}
