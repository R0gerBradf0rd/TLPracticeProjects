using OrderManager.Interfaces;

namespace OrderManager.Entities
{
    public class ClientProduct : IClientProduct
    {
        private readonly string _productName;
        private readonly int _productCount;
        private readonly string _productOwnerName;
        private readonly string _productOwnerAddress;

        public ClientProduct( string name, int count, string owner, string address )
        {
            _productName = name;
            _productCount = count;
            _productOwnerName = owner;
            _productOwnerAddress = address;
        }

        public string ProductName()
        {
            return _productName;
        }

        public int ProductCount()
        {
            return _productCount;
        }

        public string ProductOwnerName()
        {
            return _productOwnerName;
        }

        public string ProductOwnerAddress()
        {
            return _productOwnerAddress;
        }
    }
}
