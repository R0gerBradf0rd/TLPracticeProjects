using Dictionary.DictionaryMenuMediator;

namespace Dictionary.ConsoleMenu.MenuOptions
{
    public class MainMenu : IMenuMediator
    {
        private readonly IConsoleMenuDisplayer _menuDisplayer;
        public MainMenu( IConsoleMenuDisplayer menuDisplayer )
        {
            _menuDisplayer = menuDisplayer;
        }

        public int RunMenu()
        {
            _menuDisplayer.UpdatePromt( PromtsAndOptions.MainMenuPromt() );
            _menuDisplayer.UpdateOptions( PromtsAndOptions.MainMenuOptions() );

            return _menuDisplayer.GetSelectedIndex();
        }
    }
}
