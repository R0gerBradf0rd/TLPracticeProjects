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

                    var fighter = CreateFighter();

                    fighters.Add( fighter );
                }

                return fighters;

            }
        }

        private IFighter CreateFighter()
        {
            ChooseRace();
            GetName();
            ChooseWeapon();
            ChooseArmor();

            _fighter = new Fighter( _characterName, _race );
            _fighter.SetArmor( _armor );
            _fighter.SetWeapon( _weapon );

            return _fighter;
        }
        private void ChooseRace()
        {
            _messageProvider.WriteMessageWithNewLine( "Выберите рассу персонажа." );
            _messageProvider.WriteMessageWithNewLine( "1 - Ангел {Здоровье: 777, Защита: 777, Урон: 777, Инициатива: 10}" );
            _messageProvider.WriteMessageWithNewLine( "2 - Демон {Здоровье: 666, Защита: 666, Урон: 666, Инициатива: 666}" );
            _messageProvider.WriteMessageWithNewLine( "3 - Человек {Здоровье: 100, Защита: 0, Урон: 1, Инициатива: 50}" );
            _messageProvider.WriteMessageWithNewLine( "4 - Гуль {Здоровье: 1000 - 7, Защита: 1000 - 7, Урон: 1000 - 7, Инициатива: 1000 - 7}" );
            _messageProvider.WriteMessageWithNewLine( "5 - Орк {Здоровье: 150, Защита: 30, Урон: 10, Инициатива: 50}" );
            _messageProvider.WriteMessageWithNewLine( "6 - Нежить {Здоровье: 110, Защита: 0, Урон: 10, Инициатива: 60}" );
            _messageProvider.WriteMessageWithNewLine( "7 - Божество {Здоровье: 1000000000, Защита: 1000000000, Урон: 1000000000, Инициатива: 0}" );

            while ( true )
            {
                string race = _messageProvider.GetMessage();
                if ( !int.TryParse( race, out int number ) )
                {
                    _messageProvider.WriteMessageWithNewLine( "Некорректный ввод! Пожалуйста, введите цифру из списка!" );
                    continue;
                }

                _race = RaceFactory.Choose( number );

                if ( _race == null )
                {
                    _messageProvider.WriteMessageWithNewLine( "Некорректный ввод! Пожалуйста, введите цифру из списка!" );
                    continue;
                }

                return;
            }
        }

        private string GetName()
        {
            _messageProvider.WriteMessage( "Введите имя персонажа: " );
            return _characterName = _messageProvider.GetMessage();
        }

        private void ChooseArmor()
        {
            _messageProvider.WriteMessageWithNewLine( "Выберите броню персонажа." );
            _messageProvider.WriteMessageWithNewLine( "1 - Святая броня {Защита: 1001}" );
            _messageProvider.WriteMessageWithNewLine( "2 - Демоническая броня {Защита: 1000}" );
            _messageProvider.WriteMessageWithNewLine( "3 - Без брони {Защита: 0}" );
            _messageProvider.WriteMessageWithNewLine( "4 - Броня Гуля {Защита: 1000 - 7}" );
            _messageProvider.WriteMessageWithNewLine( "5 - Железная броня {Защита: 100}" );
            _messageProvider.WriteMessageWithNewLine( "6 - Алмазная броня {Защита: 200}" );

            while ( true )
            {
                string armor = _messageProvider.GetMessage();
                if ( !int.TryParse( armor, out int number ) )
                {
                    _messageProvider.WriteMessageWithNewLine( "Некорректный ввод! Пожалуйста, введите цифру из списка!" );
                    continue;
                }

                _armor = ArmorFactory.Choose( number );

                if ( _armor == null )
                {
                    _messageProvider.WriteMessageWithNewLine( "Некорректный ввод! Пожалуйста, введите цифру из списка!" );
                    continue;
                }

                return;
            }
        }

        private void ChooseWeapon()
        {
            _messageProvider.WriteMessageWithNewLine( "Выберите оружие персонажа." );
            _messageProvider.WriteMessageWithNewLine( "1 - Кулаки {Урон: 1}" );
            _messageProvider.WriteMessageWithNewLine( "2 - Нож {Урон: 20}" );
            _messageProvider.WriteMessageWithNewLine( "3 - Меч {Урон: 80}" );
            _messageProvider.WriteMessageWithNewLine( "4 - АК47 {Урон: 100}" );
            _messageProvider.WriteMessageWithNewLine( "5 - Лазерная пушка {Урон: 200}" );

            while ( true )
            {
                string weapon = _messageProvider.GetMessage();
                if ( !int.TryParse( weapon, out int number ) )
                {
                    _messageProvider.WriteMessageWithNewLine( "Некорректный ввод! Пожалуйста, введите цифру из списка!" );
                    continue;
                }

                _weapon = WeaponFactory.Choose( number );

                if ( _weapon == null )
                {
                    _messageProvider.WriteMessageWithNewLine( "Некорректный ввод! Пожалуйста, введите цифру из списка!" );
                    continue;
                }

                return;
            }
        }
    }
}
