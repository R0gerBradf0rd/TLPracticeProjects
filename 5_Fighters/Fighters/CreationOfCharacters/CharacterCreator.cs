using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;
using Fighters.UserIO;

namespace Fighters.ChooseOfCharacters
{
    public class CharacterCreator
    {
        private IUserIO _messageProvider;
        private IRace _race;
        private string _characterName;
        private IFighter _fighter;
        private IWeapon _weapon;
        private IArmor _armor;

        public CharacterCreator( IUserIO messageProvider )
        {
            _messageProvider = messageProvider;
        }

        public List<IFighter> CreateFighters()
        {
            var fighters = new List<IFighter>();

            while ( true )
            {
                _messageProvider.WriteMessage( "Ведите колличество персонажей: " );
                if ( !int.TryParse( _messageProvider.GetMessage(), out int count ) || count <= 1 )
                {
                    _messageProvider.WriteMessageWithNewLine( "Ошибка! Пожалуйста, введите число больше единицы!" );
                    continue;
                }

                for ( int i = 0; i < count; ++i )
                {
                    _messageProvider.ClearScreen();
                    _messageProvider.WriteMessageWithNewLine( $"Создание персонажа № {i + 1}" );

                    var fighter = CreateFighter();

                    fighters.Add( fighter );
                }

                return fighters;
            }
        }

        private IFighter CreateFighter()
        {
            _race = ChooseRace();
            _characterName = GetName();
            _weapon = GetWeapon();
            _armor = GetArmor();

            _fighter = new Fighter( _characterName, _race );
            _fighter.SetArmor( _armor );
            _fighter.SetWeapon( _weapon );

            return _fighter;
        }

        private IRace ChooseRace()
        {
            RaceFactory.GetRaceDescription();
            IRace race;

            while ( true )
            {
                string input = _messageProvider.GetMessage();
                if ( !int.TryParse( input, out int number ) )
                {
                    _messageProvider.WriteMessageWithNewLine( "Некорректный ввод! Пожалуйста, введите цифру из списка!" );
                    continue;
                }

                race = RaceFactory.Get( number );

                if ( race is null )
                {
                    _messageProvider.WriteMessageWithNewLine( "Некорректный ввод! Пожалуйста, введите цифру из списка!" );
                    continue;
                }

                return race;
            }
        }

        private string GetName()
        {
            _messageProvider.WriteMessage( "Введите имя персонажа: " );
            return _messageProvider.GetMessage();
        }

        private IArmor GetArmor()
        {
            ArmorFactory.GetArmorDescription();
            IArmor armor;

            while ( true )
            {
                string input = _messageProvider.GetMessage();
                if ( !int.TryParse( input, out int number ) )
                {
                    _messageProvider.WriteMessageWithNewLine( "Некорректный ввод! Пожалуйста, введите цифру из списка!" );
                    continue;
                }

                armor = ArmorFactory.Get( number );

                if ( armor is null )
                {
                    _messageProvider.WriteMessageWithNewLine( "Некорректный ввод! Пожалуйста, введите цифру из списка!" );
                    continue;
                }

                return armor;
            }
        }

        private IWeapon GetWeapon()
        {
            WeaponFactory.GetWeaponDescription();
            IWeapon weapon;

            while ( true )
            {
                string input = _messageProvider.GetMessage();
                if ( !int.TryParse( input, out int number ) )
                {
                    _messageProvider.WriteMessageWithNewLine( "Некорректный ввод! Пожалуйста, введите цифру из списка!" );
                    continue;
                }

                weapon = WeaponFactory.Get( number );

                if ( weapon is null )
                {
                    _messageProvider.WriteMessageWithNewLine( "Некорректный ввод! Пожалуйста, введите цифру из списка!" );
                    continue;
                }

                return weapon;
            }
        }
    }
}
