namespace CarFactory.UserIO
{
    public interface IUserIO
    {
        string ReadMessage();

        void WriteMessage( string message );

        void WriteMessageWithNewLine( string message );
    }
}
