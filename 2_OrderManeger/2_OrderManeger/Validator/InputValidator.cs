using OrderManager.Interfaces;

namespace OrderManager.Validator
{
    public class InputValidator : IInputValidator
    {
        private readonly IMessageHandler _messageHandler;
        private readonly Printer _printer;
        private const int _positiveAnswer = 1;
        private const int _negativeAnswer = 0;

        public InputValidator( IMessageHandler messageHandler, Printer printer )
        {
            _messageHandler = messageHandler;
            _printer = printer;
        }

        public int UserAnswerControl()
        {
            while ( true )
            {
                if ( int.TryParse( _messageHandler.InputMessage(), out int userIntInput ) && ( userIntInput == _negativeAnswer || userIntInput == _positiveAnswer ) )
                {
                    return userIntInput;
                }
                _printer.PrintInvalidAnswerError();
            }
        }

        public string UserStringInputControl()
        {
            while ( true )
            {
                string userStringInput = _messageHandler.InputMessage();
                if ( !String.IsNullOrWhiteSpace( userStringInput ) )
                {
                    return userStringInput;
                }
                _printer.PrintInvalidInputError();
            }
        }
        public string UserNameControl()
        {
            string userStringInput = _messageHandler.InputMessage();
            if ( !String.IsNullOrWhiteSpace( userStringInput ) )
            {
                return userStringInput;
            }
            return "Неизвестный пользователь";
        }
    }
}
