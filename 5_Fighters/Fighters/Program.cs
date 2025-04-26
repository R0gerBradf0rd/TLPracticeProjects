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

            var characterCreator = new CharacterCreationProcedure( messageProvider );

            messageProvider.WriteMessageWithNewLine( "Создайте первого персонажа." );
            IFighter fighterA = characterCreator.Create();
            messageProvider.ClearScreen();

            messageProvider.WriteMessageWithNewLine( "Создайте второго персонажа." );
            IFighter fighterB = characterCreator.Create();
            messageProvider.ClearScreen();

            IFighter winner;
            if ( fighterA.Initiative >= fighterB.Initiative )
            {
                winner = gameManager.Play( fighterA, fighterB );
            }
            else
            {
                winner = gameManager.Play( fighterB, fighterA );
            }
            messageProvider.WriteMessageWithNewLine( $"Победитель: {winner.Name}" );
        }
    }
}