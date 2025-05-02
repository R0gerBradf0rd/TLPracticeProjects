namespace Fighters.Models.Weapons
{
    public class WeaponFactory
    {
        public static IWeapon Choose( int number )
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
    }
}
