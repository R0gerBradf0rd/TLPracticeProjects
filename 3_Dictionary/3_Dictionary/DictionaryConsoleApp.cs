using Dictionary.ConsoleMenu.MenuOptions;
using Dictionary.ConsoleMenu.MenuRunner;
using Dictionary.DictionaryMenuMediator;
using Dictionary.Entitys;

namespace Dictionary
{
    public class DictionaryConsoleApp
    {

        private IConsoleMenuMediator _menuMediator = new ConsolemenuMediator( "", [] );
        private IMenuRunner _menuRunner;

        private readonly MainDictionary _mainDictionary;

        public DictionaryConsoleApp( MainDictionary mainDictionary )
        {
            mainDictionary.FillTheLocalDictionary();
            _mainDictionary = mainDictionary;
        }

        public void Start()
        {
            MainMenu();

            Console.WriteLine( "Goodbye!" );
            Console.ReadKey( true );
        }

        private void MainMenu()
        {
            _menuRunner = new MainMenu( _menuMediator );

            switch ( _menuRunner.GetSelectedIndex() )
            {
                case 0:
                    DictionaryMenu();
                    break;

                case 1:
                    AboutMenu();
                    break;

                case 2:
                    Exit();
                    break;

                default:
                    break;
            }
        }

        private void DictionaryMenu()
        {
            IDictionaryMenuRunner menu = new DictionaryMenu( _menuMediator, _mainDictionary );

            switch ( menu.GetSelectedIndex() )
            {
                case 0:
                    DictionaryMenu();
                    break;

                case 1:
                    MainMenu();
                    break;
                case 2:
                    AddWord( menu.TheWordOutOfDictionary(), _mainDictionary );
                    break;

                default:
                    break;
            }

        }

        private void AddWord( string userWord, MainDictionary mainDictionary )
        {
            _menuRunner = new AddWord( _menuMediator, userWord, mainDictionary );

            switch ( _menuRunner.GetSelectedIndex() )
            {
                case 0:
                    DictionaryMenu();
                    break;

                case 1:
                    MainMenu();
                    break;

                default:
                    break;
            }
        }

        private void AboutMenu()
        {
            _menuRunner = new AboutMenu( _menuMediator );

            switch ( _menuRunner.GetSelectedIndex() )
            {
                case 0:
                    MainMenu();
                    break;

                default:
                    break;
            }
        }

        private void Exit()
        {
            _mainDictionary.FillTheDictionary();
            _menuMediator.ClearScreen();
            _menuMediator.WriteMessageInNewLine( "You exited the app" );
        }
    }
}
