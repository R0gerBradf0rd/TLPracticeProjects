using Fighters.UserIO;

namespace Fighters.Models.Weapons
{
    public class WeaponFactory
    {
        public static IWeapon GetWeaponType( int number )
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

        public static string GetWeaponDescription()
        {
            return "Выберите оружие персонажа." +
                "\n1 - Кулаки {Урон: 1}" +
                "\n2 - Нож {Урон: 20}" +
                "\n3 - Меч {Урон: 80}" +
                "\n4 - АК47 {Урон: 100}" +
                "\n5 - Лазерная пушка {Урон: 200}";
        }
    }
}
