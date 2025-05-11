using CarFactory.Models.Transmisoons;

namespace CarFactory.Models.Transmissions
{
    public static class TransmissionFactory
    {
        public static ITransmission GetTransmission( int number )
        {
            switch ( number )
            {
                case 1:
                    return new MT5();

                case 2:
                    return new MT6();

                case 3:
                    return new AT6();

                case 4:
                    return new AT8();

                default:
                    return null;
            }
        }
        public static string GetTransmissionsDescription()
        {
            return "Выберите трансмиссию:" +
                "\n1 - МТ5 {Механика, 5 передач}" +
                "\n2 - МТ6 {Механика, 6 передач}" +
                "\n3 - АТ6 {Автомат, 6 передач}" +
                "\n4 - АТ8 {Автомат, 8 передач}";
        }
    }
}
