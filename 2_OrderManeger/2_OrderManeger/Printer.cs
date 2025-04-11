using OrderManager.Interfaces;

namespace OrderManager
{
    public class Printer : IPrinter
    {
        private readonly IMessageHandler _messageHandler;

        public Printer( IMessageHandler messageHandler )
        {
            _messageHandler = messageHandler;
        }

        public void PrintOrderMenu( string clientName )
        {
            _messageHandler.ShowMessageWithNewLine( $"{clientName}, для заказа необходимо запонить следующие данные:" );
            _messageHandler.ShowMessageWithNewLine( "- Название товара" );
            _messageHandler.ShowMessageWithNewLine( "- Колличество" );
            _messageHandler.ShowMessageWithNewLine( "- Имя получателя" );
            _messageHandler.ShowMessageWithNewLine( "- Адрес доставки\n" );
        }

        public void PrintConfirmMenu()
        {
            _messageHandler.ShowMessageWithNewLine( "\nДавайте проверим данные на коректность!" );
            _messageHandler.ShowMessageWithNewLine( "1 - Все верно" );
            _messageHandler.ShowMessageWithNewLine( "0 - Нужно переформление\n" );
            _messageHandler.ShowMessage( "Введите 0 или 1: " );
        }

        public void PrintExitMenu( string clientName, DateOnly todaysDate )
        {
            _messageHandler.Clear();
            _messageHandler.ShowMessageWithNewLine( $"{clientName}, Ваш заказ будет доставлен {todaysDate.AddDays( 3 )}" );
            _messageHandler.ShowMessageWithNewLine( "Хотите заказать еще?" );
            _messageHandler.ShowMessageWithNewLine( "1 - Да" );
            _messageHandler.ShowMessageWithNewLine( "0 - Нет\n" );
            _messageHandler.ShowMessage( "Введите 0 или 1: " );
        }

        public void PrintOrderInformation( string productName, int productCount, string productOwnerName, string productOwnerAddress )
        {
            _messageHandler.ShowMessageWithNewLine( "Данные о заказе" );
            _messageHandler.ShowMessageWithNewLine( $"Название товара: {productName}" );
            _messageHandler.ShowMessageWithNewLine( $"Количество: {productCount}" );
            _messageHandler.ShowMessageWithNewLine( $"Имя получателя: {productOwnerName}" );
            _messageHandler.ShowMessageWithNewLine( $"Адрес доставки: {productOwnerAddress}" );
        }

        public void PrintInvalidAnswerError()
        {

            _messageHandler.ShowMessageWithNewLine( "Введите либо 0, либо 1!" );
            _messageHandler.ShowMessage( "Пожалуйста, попробуйте еще раз: " );
        }

        public void PrintInvalidInputError()
        {
            _messageHandler.ShowMessageWithNewLine( "Данное поле не может быть пустым!" );
            _messageHandler.ShowMessage( "Пожалуйста, попробуйте еще раз: " );
        }
    }
}
