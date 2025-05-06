using Fighters.ChooseOfCharacters;
using Fighters.Models.Fighters;
using Fighters.UserIO;

namespace Fighters
{
    public class Program
    {
        public static void Main( string[] args )
        {
            IUserIO messageProvider = new ConsoleDelayIO();
            var gameManager = new GameManager( messageProvider );
            var characterCreator = new CharacterCreator( messageProvider );

            List<IFighter> fighters = characterCreator.CreateFighters();
            IFighter winner = gameManager.Fight( fighters );
            messageProvider.ClearScreen();
            messageProvider.WriteMessageWithNewLine( $"Победитель: {winner.Name}" );
        }
    }
}