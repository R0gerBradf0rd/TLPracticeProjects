namespace Dictionary.ConsoleMenu
{
    public interface IConsoleMenuManager
    {
        public void DisplayOptions();

        public int GetSelectedIndex();

        public void UpdatePromt( string newPromt );

        public void UpdateOptions( string[] newOptions );
    }
}
