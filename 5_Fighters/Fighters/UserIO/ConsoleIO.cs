namespace Fighters.UserIO
{
    public class ConsoleIO : IUserIO
    {
        public void ClearScreen()
        {
            Console.Clear();
        }

        public string GetMessage()
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
