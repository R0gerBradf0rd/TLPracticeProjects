namespace CarFactory.Models.Colours
{
    public interface IColour
    {
        string Name { get; }

        AvilableColours AvilableColour { get; }
    }
}
