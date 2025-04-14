using Dictionary.ConsoleMenu;
using Dictionary.DictionaryFileIO.FilerReader;
using Dictionary.DictionaryFileIO.FileWriter;

namespace Dictionary
{
    public class DictionaryConsoleApp
    {
        private readonly string _dictionaryFilePath;
        private readonly char _dictionarySeparator;
        private const string _enterTheWord = "Введите слово: ";
        private const string _theTranslation = "Перевод вашего слова: ";
        private const string _enterTheTranslation = "Введите перевод: ";
        private const string _addNewWord = "Ваше слово не найдено в словаре(\nЖелаете его добавить?";
        private const string _theWordAlreadyExist = "Данное слово уже есть в словаре!\n";

        private Dictionary<string, string> _enRuDictionary = new Dictionary<string, string>();
        private Dictionary<string, string> _ruEnDictionary = new Dictionary<string, string>();


        public DictionaryConsoleApp( string dictionaryFilePath, char dictionarySeparator )
        {
            _dictionaryFilePath = dictionaryFilePath;
            _dictionarySeparator = dictionarySeparator;
            IDictionaryReader fileReader = new DictionaryTxtFileReader( _dictionaryFilePath );
            fileReader.ReadDictionary( _dictionarySeparator, _enRuDictionary, _ruEnDictionary );
        }

        public void Start()
        {
            MainMenu();

            Console.WriteLine( "Goodbye!" );
            Console.ReadKey( true );
        }

        private void MainMenu()
        {
            IConsoleMenuManager mainMenu = new ConsoleMenuManager( PromtsAndOptions.MainMenuPromt(), PromtsAndOptions.MainMenuOptions() );

            int selectedIndex = mainMenu.GetSelectedIndex();

            switch ( selectedIndex )
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
            Console.Clear();
            IConsoleMenuManager dictionaryMenu = new ConsoleMenuManager( PromtsAndOptions.DictionaryMenuPromt(), PromtsAndOptions.DictionaryMenuOptions() );

            Console.Write( _enterTheWord );
            string userInput = Console.ReadLine();
            string newPromt = _enterTheWord + userInput + "\n";

            bool isWordInDictionary;
            if ( _enRuDictionary.ContainsKey( userInput ) )
            {
                Console.WriteLine( $"{_theTranslation}{_enRuDictionary[ userInput ]}" );
                newPromt = newPromt + _theTranslation + _enRuDictionary[ userInput ] + "\n";
                isWordInDictionary = true;
            }
            else if ( _enRuDictionary.ContainsValue( userInput ) )
            {
                Console.WriteLine( $"Перевод: {_ruEnDictionary[ userInput ]}" );
                newPromt = newPromt + _theTranslation + _ruEnDictionary[ userInput ] + "\n";
                isWordInDictionary = true;
            }
            else
                isWordInDictionary = false;

            if ( isWordInDictionary )
            {
                dictionaryMenu.UpdatePromt( newPromt );
                int selectedIndex = dictionaryMenu.GetSelectedIndex();

                switch ( selectedIndex )
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
            else
            {
                newPromt = _addNewWord + "\n";
                dictionaryMenu.UpdatePromt( newPromt );
                dictionaryMenu.UpdateOptions( PromtsAndOptions.DictionaryNoWordMenuOptions() );
                int selectedIndex = dictionaryMenu.GetSelectedIndex();

                switch ( selectedIndex )
                {
                    case 0:
                        AddWord( userInput, _enRuDictionary, _ruEnDictionary );
                        break;

                    case 1:
                        DictionaryMenu();
                        break;

                    case 2:
                        MainMenu();
                        break;

                    default:
                        break;
                }
            }
        }

        private void AddWord( string userWord, Dictionary<string, string> dictionary, Dictionary<string, string> dictionaryReversed )
        {
            IConsoleMenuManager addWord = new ConsoleMenuManager( PromtsAndOptions.AddWordMenuPromt(), PromtsAndOptions.AddWordMenuOptions() );

            Console.Clear();
            Console.Write( _enterTheTranslation );
            string userInput = Console.ReadLine();

            if ( dictionary.ContainsKey( userInput ) && dictionaryReversed.ContainsKey( userWord ) )
            {
                dictionary.Add( userInput, userWord );
                dictionaryReversed.Add( userWord, userInput );
            }
            else
            {
                addWord.UpdatePromt( _theWordAlreadyExist );
            }

            int selectedIndex = addWord.GetSelectedIndex();

            switch ( selectedIndex )
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
            IConsoleMenuManager aboutMenu = new ConsoleMenuManager( PromtsAndOptions.AboutMenuPromt(), PromtsAndOptions.AboutMenuOptions() );

            int selectedIndex = aboutMenu.GetSelectedIndex();

            switch ( selectedIndex )
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
            IDictionaryWriter fileWriter = new DictionaryTxtFileWriter( _dictionarySeparator );
            fileWriter.WriteDictionary( _dictionaryFilePath, _enRuDictionary );
            Console.Clear();
            Console.WriteLine( "You exited the app" );
        }
    }
}
