namespace CarFactory.Models.Bodyworks
{
    public interface IBodywork
    {
        string Name { get; }

        public double Weight { get; }

        public double FrontalArea { get; }
    }
}
