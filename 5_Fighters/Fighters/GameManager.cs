using System.Text;
using Fighters.ChooseOfCharacters;
using Fighters.Extensions;
using Fighters.Models.Fighters;
using Fighters.UserIO;

namespace Fighters
{
    public class GameManager
    {
        private IUserIO _messageProvider;

        private CharacterCreator _characterCreator;

        private List<IFighter> _fighterList;

        public GameManager( IUserIO messageProvider )
        {
            _messageProvider = messageProvider;
            _characterCreator = new( messageProvider );
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

        public IFighter Fight( List<IFighter> fighters )
        {
            _fighterList = fighters;
            int rounds = 0;

            for ( int i = 0; _fighterList.Count > 1; i++ )
            {
                if ( i == _fighterList.Count )
                {
                    i = 0;
                }
                _fighterList = _fighterList.OrderByDescending( fighter => fighter.Initiative ).ToList();

                _messageProvider.ClearScreen();
                _messageProvider.WriteMessageWithNewLine( $"Раунд {++rounds}:" );
                Thread.Sleep( 1000 );

                var randomFighter = new Random();
                var firstFighter = _fighterList[ i ];
                _fighterList.Remove( firstFighter );
                var secondFighter = _fighterList[ randomFighter.Next( 0, _fighterList.Count() - 1 ) ];

                var firstFighterDamage = firstFighter.CalculateDamage();
                secondFighter.TakeDamage( firstFighterDamage );
                _messageProvider.WriteMessageWithNewLine( $"Боец {firstFighter.Name} бьет Бойца {secondFighter.Name} и на носит {firstFighterDamage} единиц урона" );

                _messageProvider.WriteMessageWithNewLine( $"Состояние бойца {firstFighter.Name}:" );
                firstFighter.ShowCurrentHealthAndArmor();

                _messageProvider.WriteMessageWithNewLine( $"Состояние бойца {secondFighter.Name}:" );
                secondFighter.ShowCurrentHealthAndArmor();
                if ( !secondFighter.IsAlive() )
                {
                    _messageProvider.WriteMessageWithNewLine( $"Боец {secondFighter.Name} пал в бою!" );
                    _fighterList.Remove( secondFighter );
                }

                Thread.Sleep( 1000 );
                _messageProvider.WriteMessageWithNewLine( "Нажмите любую клавишу, чтобы продолжить" );
                _messageProvider.WhaitForKeyPress();

                _fighterList.Add( firstFighter );
            }
            return _fighterList[ 0 ];
        }
    }
}