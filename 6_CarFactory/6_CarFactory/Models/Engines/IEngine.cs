namespace CarFactory.Models.Engiens
{
    public interface IEngine
    {
        public int HorsePower { get; }

        public double Weight { get; }

        public string Name { get; }
    }
}
