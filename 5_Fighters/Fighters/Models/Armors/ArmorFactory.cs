using Fighters.UserIO;

namespace Fighters.Models.Armors
{
    public class ArmorFactory
    {
        public static IArmor Get( int number )
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

        public static void GetArmorDescription()
        {
            IUserIO messageProvider = new ConsoleDelayIO();
            messageProvider.WriteMessageWithNewLine( "Выберите броню персонажа." );
            messageProvider.WriteMessageWithNewLine( "1 - Святая броня {Защита: 1001}" );
            messageProvider.WriteMessageWithNewLine( "2 - Демоническая броня {Защита: 1000}" );
            messageProvider.WriteMessageWithNewLine( "3 - Без брони {Защита: 0}" );
            messageProvider.WriteMessageWithNewLine( "4 - Броня Гуля {Защита: 1000 - 7}" );
            messageProvider.WriteMessageWithNewLine( "5 - Железная броня {Защита: 100}" );
            messageProvider.WriteMessageWithNewLine( "6 - Алмазная броня {Защита: 200}" );
        }
    }
}
