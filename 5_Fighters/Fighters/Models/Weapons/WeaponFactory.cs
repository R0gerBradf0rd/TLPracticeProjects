using Fighters.UserIO;

namespace Fighters.Models.Weapons
{
    public class WeaponFactory
    {
        public static IWeapon Get( int number )
        {
            switch ( number )
            {
                case 1:
                    return new Fists();

                case 2:
                    return new Knife();

                case 3:
                    return new Sword();

                case 4:
                    return new AK47();

                case 5:
                    return new LaserGun();

                default:
                    return null;
            }
        }

        public static void GetWeaponDescription()
        {
            IUserIO messageProvider = new ConsoleDelayIO();
            messageProvider.WriteMessageWithNewLine( "Выберите оружие персонажа." );
            messageProvider.WriteMessageWithNewLine( "1 - Кулаки {Урон: 1}" );
            messageProvider.WriteMessageWithNewLine( "2 - Нож {Урон: 20}" );
            messageProvider.WriteMessageWithNewLine( "3 - Меч {Урон: 80}" );
            messageProvider.WriteMessageWithNewLine( "4 - АК47 {Урон: 100}" );
            messageProvider.WriteMessageWithNewLine( "5 - Лазерная пушка {Урон: 200}" );
        }
    }
}
