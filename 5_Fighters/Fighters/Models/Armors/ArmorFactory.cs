using Fighters.UserIO;

namespace Fighters.Models.Armors
{
    public class ArmorFactory
    {
        public static IArmor GetArmorType( int number )
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

        public static string GetArmorDescription()
        {
            return "Выберите броню персонажа." +
                "\n1 - Святая броня {Защита: 1001}" +
                "\n2 - Демоническая броня {Защита: 1000}" +
                "\n3 - Без брони {Защита: 0}" +
                "\n4 - Броня Гуля {Защита: 1000 - 7}" +
                "\n5 - Железная броня {Защита: 100}" +
                "\n6 - Алмазная броня {Защита: 200}";
        }
    }
}
