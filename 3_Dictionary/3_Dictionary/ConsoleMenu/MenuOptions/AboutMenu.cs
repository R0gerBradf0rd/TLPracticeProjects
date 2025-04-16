using Dictionary.DictionaryMenuMediator;

namespace Dictionary.ConsoleMenu.MenuOptions
{
    public class AboutMenu : IMenuMediator
    {
        private readonly IConsoleMenuDisplayer _menuDisplayer;
        public AboutMenu( IConsoleMenuDisplayer menuDisplayer )
        {
            _menuDisplayer = menuDisplayer;
        }
        public int RunMenu()
        {
            _menuDisplayer.UpdatePromt( PromtsAndOptions.AboutMenuPromt() );
            _menuDisplayer.UpdateOptions( PromtsAndOptions.AboutMenuOptions() );

            return _menuDisplayer.GetSelectedIndex(); ;
        }
    }
}
