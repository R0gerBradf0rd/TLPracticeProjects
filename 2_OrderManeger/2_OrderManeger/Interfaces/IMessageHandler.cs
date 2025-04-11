namespace OrderManager.Interfaces
{
    public interface IMessageHandler
    {
        string InputMessage();

        void ShowMessage( string message );

        void ShowMessageWithNewLine( string message );

        void Clear();
    }
}