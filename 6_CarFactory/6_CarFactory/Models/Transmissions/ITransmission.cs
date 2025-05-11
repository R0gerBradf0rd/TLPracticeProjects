namespace CarFactory.Models.Transmisoons
{
    public interface ITransmission
    {
        string Name { get; }

        int GearsAmount { get; }

        public double Weight { get; }
    }
}
