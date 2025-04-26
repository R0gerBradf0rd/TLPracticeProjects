using Fighters.Extensions;
using Fighters.Models.Fighters;
using Fighters.UserIO;

namespace Fighters
{
    public class GameManager
    {
        private IUserIO _messageProvider;

        public GameManager( IUserIO messageProvider )
        {
            _messageProvider = messageProvider;
        }
        public IFighter Play( IFighter fighterA, IFighter fighterB )
        {
            int round = 0;
            while ( true )
            {
                Thread.Sleep( 1000 );
                _messageProvider.WriteMessageWithNewLine( $"Раунд {++round}:" );

                Thread.Sleep( 2000 );
                var firstFighterDamage = fighterA.CalculateDamage();
                fighterB.TakeDamage( firstFighterDamage );
                _messageProvider.WriteMessageWithNewLine( $"Боец {fighterA.Name} бьет Бойца {fighterB.Name} и на носит {firstFighterDamage} единиц урона" );
                fighterA.ShowCurrentHealthAndArmor();
                Thread.Sleep( 2000 );
                if ( !fighterB.IsAlive() )
                {
                    return fighterA;
                }

                var secondFighterDamage = fighterB.CalculateDamage();
                fighterA.TakeDamage( secondFighterDamage );
                _messageProvider.WriteMessageWithNewLine( $"Боец {fighterB.Name} бьет Бойца {fighterA.Name} и на носит {secondFighterDamage} единиц урона" );
                fighterB.ShowCurrentHealthAndArmor();
                Thread.Sleep( 2000 );
                if ( !fighterA.IsAlive() )
                {
                    return fighterB;
                }

                _messageProvider.ClearScreen();
            }
        }
    }
}