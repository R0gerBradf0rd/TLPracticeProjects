namespace Fighters.UserIO
{
    public interface IUserIO
    {
        void WriteMessage( string message );

        void WriteMessageWithNewLine( string message );

        string GetMessage();

        void ClearScreen();

        void WhaitForKeyPress();
    }
}
