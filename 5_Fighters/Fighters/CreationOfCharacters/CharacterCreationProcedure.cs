using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;
using Fighters.UserIO;

namespace Fighters.ChooseOfCharacters
{
    public class CharacterCreationProcedure
    {
        private IUserIO _messageProvider;
        private IRace _race;
        private string _characterName;
        private IFighter _fighter;
        private IWeapon _weapon;
        private IArmor _armor;

        public CharacterCreationProcedure( IUserIO messageProvider )
        {
            _messageProvider = messageProvider;
        }

        public IFighter Create()
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
                if ( !int.TryParse( race, out int number ) || number > 7 || number < 1 )
                {
                    _messageProvider.WriteMessageWithNewLine( "Некорректный ввод! Пожалуйста, введите цифру из списка!" );
                    continue;
                }
                switch ( number )
                {
                    case 1:
                        _race = new Angel();
                        return;

                    case 2:
                        _race = new Demon();
                        return;

                    case 3:
                        _race = new Human();
                        return;

                    case 4:
                        _race = new Ghoul();
                        return;
                    case 5:
                        _race = new Ork();
                        return;

                    case 6:
                        _race = new Undead();
                        return;

                    case 7:
                        _race = new God();
                        return;

                    default:
                        return;
                }
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
                if ( !int.TryParse( armor, out int number ) || number > 7 || number < 1 )
                {
                    _messageProvider.WriteMessageWithNewLine( "Некорректный ввод! Пожалуйста, введите цифру из списка!" );
                    continue;
                }
                switch ( number )
                {
                    case 1:
                        _armor = new HolyArmor();
                        return;

                    case 2:
                        _armor = new DemonicArmor();
                        return;

                    case 3:
                        _armor = new NoArmor();
                        return;

                    case 4:
                        _armor = new GhoulArmor();
                        return;

                    case 5:
                        _armor = new IronArmor();
                        return;

                    case 6:
                        _armor = new DimondArmor();
                        return;

                    default:
                        return;
                }
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
                if ( !int.TryParse( weapon, out int number ) || number > 7 || number < 1 )
                {
                    _messageProvider.WriteMessageWithNewLine( "Некорректный ввод! Пожалуйста, введите цифру из списка!" );
                    continue;
                }
                switch ( number )
                {
                    case 1:
                        _weapon = new Fists();
                        return;

                    case 2:
                        _weapon = new Knife();
                        return;

                    case 3:
                        _weapon = new Sword();
                        return;

                    case 4:
                        _weapon = new AK47();
                        return;

                    case 5:
                        _weapon = new LaserGun();
                        return;

                    default:
                        return;
                }
            }
        }
    }
}
