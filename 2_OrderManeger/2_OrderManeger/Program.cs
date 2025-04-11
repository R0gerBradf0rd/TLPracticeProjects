using OrderManager.ConsoleUI;
using OrderManager.Interfaces;

namespace OrderManager
{
    internal class Program
    {
        static void Main( string[] args )
        {
            IMessageHandler messageHandler = new ConsoleMessageHandler();

            OrderManager orderMenager = new OrderManager( messageHandler );

            orderMenager.Start();
        }
    }
}
