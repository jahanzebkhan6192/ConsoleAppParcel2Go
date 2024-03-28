namespace ConsoleAppParcel2Go
{
    public class Checkout : ICheckout
    {
        List<string> _services = new();
        private IMultibuyStrategy _serviceProduct;

        List<PricePlan> _pricePlan { get; set; }

        public Checkout(IMultibuyStrategy serviceProduct, List<PricePlan> pricePlan)
        {
            _serviceProduct = serviceProduct;
            _pricePlan = pricePlan;
        }

        public double GetTotalPrice()
        {
            double totalPrice = 0;
            foreach (var service in _services.Select(x => x).Distinct())
            {
                var noOfServices = _services.Count(x => x == service);

                var pricePlan = _pricePlan.FirstOrDefault(x => x.Name == service);

                if (pricePlan != null) {

                    totalPrice = totalPrice + _serviceProduct.Calculate(noOfServices, pricePlan);
                }
            }

            return totalPrice;
        }

        public void Scan(string service)
        {
            _services.Add(service);
        }

        public void Clear()
        {
            _services.Clear();
        }
    }
}