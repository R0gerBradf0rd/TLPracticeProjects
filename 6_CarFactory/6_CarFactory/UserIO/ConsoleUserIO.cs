namespace CarFactory.UserIO
{
    public class ConsoleUserIO : IUserIO
    {
        public string ReadMessage()
        {
            return Console.ReadLine();
        }

        public void WriteMessage( string message )
        {
            Console.Write( message );
        }

        public void WriteMessageWithNewLine( string message )
        {
            Console.WriteLine( message );
        }
    }
}
