namespace Fighters.UserIO
{
    public class ConsoleDelayIO : IUserIO
    {
        public string GetMessage()
        {
            return Console.ReadLine();
        }

        public void WriteMessage( string message )
        {
            foreach ( char item in message )
            {
                Console.Write( item );
                Thread.Sleep( 5 );
            }
        }

        public void WriteMessageWithNewLine( string message )
        {
            foreach ( char item in message )
            {
                Console.Write( item );
                Thread.Sleep( 5 );
            }
            Console.WriteLine();
        }
        public void ClearScreen()
        {
            Console.Clear();
        }
    }
}
