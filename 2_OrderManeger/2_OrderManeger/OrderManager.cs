using OrderManager.Entities;
using OrderManager.Interfaces;
using OrderManager.Validator;

namespace OrderManager
{
    public class OrderManager : IOrderManager
    {
        private readonly IMessageHandler _messageHandler;
        private readonly Printer _printer;

        private const int _positiveAnswer = 1;
        private const int _negativeAnswer = 0;

        public OrderManager( IMessageHandler messageHandler )
        {
            _messageHandler = messageHandler;
            _printer = new Printer( _messageHandler );
        }

        public void Start()
        {
            bool inProces = true;
            DateOnly todaysDate = DateOnly.FromDateTime( DateTime.Now );
            InputValidator validator = new InputValidator( _messageHandler, _printer );

            _messageHandler.ShowMessage( "Добрый день! Напишите, как к вам обращаться: " );
            string clientName = validator.UserNameControl();

            _printer.PrintOrderMenu( clientName );
            while ( inProces )
            {
                _messageHandler.ShowMessage( "Введите название товара: " );
                string productName = validator.UserStringInputControl();

                _messageHandler.ShowMessage( "Введите количество товара: " );
                string productCountString = validator.UserStringInputControl();
                if ( !int.TryParse( productCountString, out int productCount ) )
                {
                    productCount = 1;
                    _messageHandler.ShowMessageWithNewLine( "Число не распознано" );
                    _messageHandler.ShowMessageWithNewLine( "Количество товара установлено по умолчанию: 1" );
                }

                _messageHandler.ShowMessage( "На чье имя будет выдан заказ: " );
                string ownerName = validator.UserStringInputControl();

                _messageHandler.ShowMessage( "Введите адрес доставки: " );
                string address = validator.UserStringInputControl();

                ClientProduct product = new ClientProduct( productName, productCount, ownerName, address );

                _messageHandler.Clear();
                _printer.PrintOrderInformation( product.ProductName(), product.ProductCount(), product.ProductOwnerName(), product.ProductOwnerAddress() );

                _printer.PrintConfirmMenu();
                int userInput = validator.UserAnswerControl();

                if ( userInput == _negativeAnswer )
                {
                    _messageHandler.Clear();
                    continue;
                }

                _printer.PrintExitMenu( clientName, todaysDate );

                userInput = validator.UserAnswerControl();

                if ( userInput == _positiveAnswer )
                {
                    _messageHandler.Clear();
                    continue;
                }

                inProces = false;
                _messageHandler.Clear();
            }

            _messageHandler.ShowMessageWithNewLine( $"{clientName}, спасибо, что воспользовались нашим приложением!\nДосвидания!" );
        }
    }
}
