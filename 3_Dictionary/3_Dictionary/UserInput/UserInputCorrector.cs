namespace Dictionary.UserInput
{
    public static class UserInputCorrector
    {
        public static string GetInput()
        {
            while ( true )
            {
                string userInput = Console.ReadLine();
                string[] words = userInput.Split( new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries );

                if ( words.Length == 1 )
                {
                    return userInput.ToLower();
                }
                else
                {
                    throw new Exception( "Некорректный ввод" );
                }
            }
        }
    }
}
