using Fighters.Extensions;
using Fighters.Models.Fighters;
using Fighters.UserIO;

namespace Fighters
{
    public class GameManager
    {
        private IUserIO _messageProvider;

        private List<IFighter> _fighterList;

        public GameManager( IUserIO messageProvider )
        {
            _messageProvider = messageProvider;
        }

        public IFighter Fight( List<IFighter> fighters )
        {
            _fighterList = fighters;
            int rounds = 0;

            for ( int i = 0; _fighterList.Count > 1; i++ )
            {
                if ( i >= _fighterList.Count )
                {
                    i = 0;
                }
                _fighterList = _fighterList.OrderByDescending( fighter => fighter.Initiative )
                    .ToList();

                _messageProvider.ClearScreen();
                _messageProvider.WriteMessageWithNewLine( $"Раунд {++rounds}:" );
                Thread.Sleep( 1000 );

                var randomIndex = new Random();
                var fighter = _fighterList[ i ];
                _fighterList.Remove( fighter );
                var enemy = _fighterList[ randomIndex.Next( 0, _fighterList.Count() - 1 ) ];

                var firstFighterDamage = fighter.CalculateDamage();
                enemy.TakeDamage( firstFighterDamage );
                _messageProvider.WriteMessageWithNewLine( $"Боец {fighter.Name} бьет Бойца {enemy.Name} и на носит {firstFighterDamage} единиц урона" );

                _messageProvider.WriteMessageWithNewLine( $"Состояние бойца {fighter.Name}:" );
                fighter.ShowCurrentHealthAndArmor();

                _messageProvider.WriteMessageWithNewLine( $"Состояние бойца {enemy.Name}:" );
                enemy.ShowCurrentHealthAndArmor();
                if ( !enemy.IsAlive() )
                {
                    _messageProvider.WriteMessageWithNewLine( $"Боец {enemy.Name} пал в бою!" );
                    _fighterList.Remove( enemy );
                }

                Thread.Sleep( 1000 );
                _messageProvider.WriteMessageWithNewLine( "Нажмите любую клавишу, чтобы продолжить" );
                _messageProvider.WhaitForKeyPress();

                _fighterList.Add( fighter );
            }

            return _fighterList[ 0 ];
        }
    }
}