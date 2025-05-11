using CarFactory.Models.Transmisoons;

namespace CarFactory.Models.Transmissions
{
    public class AT6 : ITransmission
    {
        public int GearsAmount => 6;

        public double Weight => 70;

        public string Name => "Автоматическая, 6 передач";
    }
}
