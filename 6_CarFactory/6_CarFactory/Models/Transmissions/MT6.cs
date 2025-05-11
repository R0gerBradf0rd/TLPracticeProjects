using CarFactory.Models.Transmisoons;

namespace CarFactory.Models.Transmissions
{
    public class MT6 : ITransmission
    {
        public int GearsAmount => 6;

        public double Weight => 45;

        public string Name => "Механическая, 6 передач";
    }
}
