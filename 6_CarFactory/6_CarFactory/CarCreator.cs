using System.Drawing;
using CarFactory.Models.Bodyworks;
using CarFactory.Models.Car;
using CarFactory.Models.CarBrands;
using CarFactory.Models.Colours;
using CarFactory.Models.Engiens;
using CarFactory.Models.Engines;
using CarFactory.Models.Transmisoons;
using CarFactory.Models.Transmissions;
using CarFactory.UserIO;

namespace CarFactory
{
    public class CarCreator
    {
        private IUserIO _messageProvider;

        private ICarBrand _brand;

        private IBodywork _bodywork;

        private IEngine _engine;

        private ITransmission _transmission;

        private IColour _colour;

        public CarCreator( IUserIO messageProvider )
        {
            _messageProvider = messageProvider;
        }

        public ICar CreateCar()
        {
            _bodywork = GetBodywork();
            _engine = GetEngine();
            _transmission = GetTransmission();
            _colour = GetColour();
            _brand = GetCarBrand();
            ICar car;
            return car = new Car( _brand, _bodywork, _colour, _engine, _transmission );
        }

        private IEngine GetEngine()
        {
            _messageProvider.WriteMessageWithNewLine( EngineFactory.GetEnginesDescription() );
            IEngine engine;

            while ( true )
            {
                string input = _messageProvider.ReadMessage();
                if ( !int.TryParse( input, out int number ) )
                {
                    _messageProvider.WriteMessageWithNewLine( "Некорректный ввод! Пожалуйста, введите цифру из списка!" );
                    continue;
                }

                engine = EngineFactory.GetEngine( number );

                if ( engine is null )
                {
                    _messageProvider.WriteMessageWithNewLine( "Некорректный ввод! Пожалуйста, введите цифру из списка!" );
                    continue;
                }

                return engine;
            }
        }

        private IBodywork GetBodywork()
        {
            _messageProvider.WriteMessageWithNewLine( BodyworkFactory.GetBodyworkDescription() );
            IBodywork bodywork;

            while ( true )
            {
                string input = _messageProvider.ReadMessage();
                if ( !int.TryParse( input, out int number ) )
                {
                    _messageProvider.WriteMessageWithNewLine( "Некорректный ввод! Пожалуйста, введите цифру из списка!" );
                    continue;
                }

                bodywork = BodyworkFactory.GetBodywork( number );

                if ( bodywork is null )
                {
                    _messageProvider.WriteMessageWithNewLine( "Некорректный ввод! Пожалуйста, введите цифру из списка!" );
                    continue;
                }

                return bodywork;
            }
        }

        private ITransmission GetTransmission()
        {
            _messageProvider.WriteMessageWithNewLine( TransmissionFactory.GetTransmissionsDescription() );
            ITransmission transmission;

            while ( true )
            {
                string input = _messageProvider.ReadMessage();
                if ( !int.TryParse( input, out int number ) )
                {
                    _messageProvider.WriteMessageWithNewLine( "Некорректный ввод! Пожалуйста, введите цифру из списка!" );
                    continue;
                }

                transmission = TransmissionFactory.GetTransmission( number );

                if ( transmission is null )
                {
                    _messageProvider.WriteMessageWithNewLine( "Некорректный ввод! Пожалуйста, введите цифру из списка!" );
                    continue;
                }

                return transmission;
            }
        }

        private IColour GetColour()
        {
            _messageProvider.WriteMessageWithNewLine( ColoursFactory.GetColourDescription() );
            IColour colour;

            while ( true )
            {
                string input = _messageProvider.ReadMessage();
                if ( !int.TryParse( input, out int number ) )
                {
                    _messageProvider.WriteMessageWithNewLine( "Некорректный ввод! Пожалуйста, введите цифру из списка!" );
                    continue;
                }

                colour = ColoursFactory.GetColour( number );

                if ( colour is null )
                {
                    _messageProvider.WriteMessageWithNewLine( "Некорректный ввод! Пожалуйста, введите цифру из списка!" );
                    continue;
                }

                return colour;
            }
        }

        private ICarBrand GetCarBrand()
        {
            _messageProvider.WriteMessageWithNewLine( CarBrandFactory.GetCarBrandDescription() );
            ICarBrand carBrand;

            while ( true )
            {
                string input = _messageProvider.ReadMessage();
                if ( !int.TryParse( input, out int number ) )
                {
                    _messageProvider.WriteMessageWithNewLine( "Некорректный ввод! Пожалуйста, введите цифру из списка!" );
                    continue;
                }

                carBrand = CarBrandFactory.GetCarBrand( number );

                if ( carBrand is null )
                {
                    _messageProvider.WriteMessageWithNewLine( "Некорректный ввод! Пожалуйста, введите цифру из списка!" );
                    continue;
                }

                return carBrand;
            }
        }
    }
}
