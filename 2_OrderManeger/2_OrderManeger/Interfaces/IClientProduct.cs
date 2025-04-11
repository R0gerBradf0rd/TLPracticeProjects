namespace OrderManager.Interfaces
{
    public interface IClientProduct
    {
        public string ProductName();

        public int ProductCount();

        public string ProductOwnerName();

        public string ProductOwnerAddress();
    }
}
