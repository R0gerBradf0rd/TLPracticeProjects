namespace OrderManager.Interfaces
{
    public interface IPrinter
    {
        public void PrintOrderMenu( string clientName );

        public void PrintConfirmMenu();

        public void PrintExitMenu( string clientName, DateOnly todaysDate );

        public void PrintOrderInformation( string productName, int productCount, string productOwnerName, string productOwnerAddress );

        public void PrintInvalidAnswerError();

        public void PrintInvalidInputError();
    }
}
