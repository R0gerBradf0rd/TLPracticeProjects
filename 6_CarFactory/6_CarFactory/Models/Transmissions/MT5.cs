using CarFactory.Models.Transmisoons;

namespace CarFactory.Models.Transmissions
{
    public class MT5 : ITransmission
    {
        public int GearsAmount => 5;

        public double Weight => 40;

        public string Name => "Механическая, 5 передач";
    }
}
