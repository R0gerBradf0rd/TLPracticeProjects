using Fighters.Extensions;
using Fighters.Models.Fighters;

namespace Fighters
{
    public class GameManager
    {
        public IFighter Play( IFighter fighterA, IFighter fighterB )
        {
            while ( true )
            {
                var firstFighterDamage = fighterA.CalculateDamage();
                fighterB.TakeDamage( firstFighterDamage );
                Console.WriteLine( $"Fighter {fighterA.Name} hit Fighter {fighterB.Name} with {firstFighterDamage} damage" );
                if ( !fighterB.IsAlive() )
                {
                    return fighterA;
                }

                var secondFughterDamage = fighterB.CalculateDamage();
                fighterA.TakeDamage( secondFughterDamage );
                Console.WriteLine( $"Fighter {fighterB.Name} hit Fighter {fighterA.Name} with {secondFughterDamage} damage" );
                if ( !fighterA.IsAlive() )
                {
                    return fighterB;
                }
            }
        }
    }
}