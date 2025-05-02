namespace Fighters.Models.Armors
{
    public class ArmorFactory
    {
        public static IArmor Choose( int number )
        {
            switch ( number )
            {
                case 1:
                    return new HolyArmor();

                case 2:
                    return new DemonicArmor();

                case 3:
                    return new NoArmor();

                case 4:
                    return new GhoulArmor();

                case 5:
                    return new IronArmor();

                case 6:
                    return new DimondArmor();

                default:
                    return null;
            }
        }
    }
}
