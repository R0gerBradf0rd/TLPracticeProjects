using Dictionary.ConsoleMenu.MenuRunner;
using Dictionary.DictionaryMenuMediator;

namespace Dictionary.ConsoleMenu.MenuOptions
{
    public class MainMenu : IMenuRunner
    {
        private readonly IConsoleMenuMediator _menuMediator;
        public MainMenu( IConsoleMenuMediator menuMediator )
        {
            _menuMediator = menuMediator;
        }

        public void RunMenu()
        {
            _menuMediator.SetTittle( TitelsAndOptions.MainMenuPromt() );
            _menuMediator.SetOptions( TitelsAndOptions.MainMenuOptions() );
        }

        public int GetSelectedIndex()
        {
            RunMenu();
            return _menuMediator.GetSelectedIndex();
        }
    }
}
