using OrderManager.Interfaces;

namespace OrderManager.ConsoleUI
{
    public class ConsoleMessageHandler : IMessageHandler
    {
        public string InputMessage()
        {
            return Console.ReadLine();
        }

        public void ShowMessage( string message )
        {
            Console.Write( message );
        }

        public void ShowMessageWithNewLine( string message )
        {
            Console.WriteLine( message );
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
