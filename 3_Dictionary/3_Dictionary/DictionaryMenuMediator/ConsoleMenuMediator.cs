namespace Dictionary.DictionaryMenuMediator
{
    public class ConsolemenuMediator : IConsoleMenuMediator
    {
        private int _selectedIndex;
        private string[] _options;
        private string _promt;

        public ConsolemenuMediator( string promt, string[] options )
        {
            _promt = promt;
            _options = options;
            _selectedIndex = 0;
        }
        public void DisplayOptions()
        {
            Console.WriteLine( _promt );
            for ( int i = 0; i < _options.Length; i++ )
            {
                string currentOption = _options[ i ];
                string prefix;

                if ( i == _selectedIndex )
                {
                    prefix = "*";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.WriteLine( $"{prefix}<< {currentOption} >>" );
            }
            Console.ResetColor();
        }

        public int GetSelectedIndex()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                keyPressed = keyInfo.Key;

                if ( keyPressed == ConsoleKey.UpArrow && _selectedIndex > 0 )
                {
                    _selectedIndex--;
                }
                else if ( keyPressed == ConsoleKey.DownArrow && _selectedIndex < _options.Length - 1 )
                {
                    _selectedIndex++;
                }

            } while ( keyPressed != ConsoleKey.Enter );

            return _selectedIndex;
        }

        public void SetTittle( string newPromt )
        {
            _promt = newPromt;
        }

        public void SetOptions( string[] newOptions )
        {
            _options = newOptions;
            _selectedIndex = 0;
        }

        public void WriteMessage( string message )
        {
            Console.Write( message );
        }

        public void WriteMessageInNewLine( string message )
        {
            Console.WriteLine( message );
        }

        public void ClearScreen()
        {
            Console.Clear();
        }
    }
}
