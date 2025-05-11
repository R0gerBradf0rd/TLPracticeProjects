using CarFactory.Models.Car;
using CarFactory.UserIO;

namespace CarFactory
{
    internal class Program
    {
        static void Main( string[] args )
        {
            IUserIO messageProvider = new ConsoleUserIO();
            CarCreator carCreator = new CarCreator( messageProvider );
            ICar car = carCreator.CreateCar();

            messageProvider.WriteMessageWithNewLine( "Ваша машина:" );
            messageProvider.WriteMessageWithNewLine( CarConfiguration.GetCarConfiguration( car ) );
        }
    }
}
