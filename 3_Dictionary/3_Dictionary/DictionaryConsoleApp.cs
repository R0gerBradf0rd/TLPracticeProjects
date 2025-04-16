using Dictionary.ConsoleMenu;
using Dictionary.Entitys;
using Dictionary.DictionaryFileIO.FilerReader;
using Dictionary.DictionaryFileIO.FileWriter;
using Dictionary.DictionaryMenuMediator;
using Dictionary.ConsoleMenu.MenuOptions;

namespace Dictionary
{
    public class DictionaryConsoleApp
    {

        private IConsoleMenuDisplayer _menuDisplayer = new ConsoleMenuDisplayer( "", [] );
        private IMenuMediator _menuMediator;

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
            _menuMediator = new MainMenu( _menuDisplayer );

            switch ( _menuMediator.RunMenu() )
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
            IDictionaryMenuMediator menu = new DictionaryMenu( _menuDisplayer, _mainDictionary );

            switch ( menu.RunMenu() )
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
            _menuMediator = new AddWord( _menuDisplayer, userWord, mainDictionary );

            switch ( _menuMediator.RunMenu() )
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
            _menuMediator = new AboutMenu( _menuDisplayer );

            switch ( _menuMediator.RunMenu() )
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
            Console.Clear();
            Console.WriteLine( "You exited the app" );
        }
    }
}
