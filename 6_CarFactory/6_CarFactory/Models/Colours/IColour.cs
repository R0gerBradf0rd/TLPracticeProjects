namespace CarFactory.Models.Colours
{
    public interface IColour
    {
        string Name { get; }

        Colour AvilableColour { get; }
    }
}
