using Dictionary.ConsoleMenu.MenuRunner;
using Dictionary.DictionaryMenuMediator;

namespace Dictionary.ConsoleMenu.MenuOptions
{
    public class AboutMenu : IMenuRunner
    {
        private readonly IConsoleMenuMediator _menuMediator;
        public AboutMenu( IConsoleMenuMediator menuMediator )
        {
            _menuMediator = menuMediator;
        }
        private void RunMenu()
        {
            _menuMediator.SetTittle( TitelsAndOptions.AboutMenuPromt() );
            _menuMediator.SetOptions( TitelsAndOptions.AboutMenuOptions() );
        }

        public int GetSelectedIndex()
        {
            RunMenu();
            return _menuMediator.GetSelectedIndex();
        }
    }
}
