
namespace ConsoleAppParcel2Go
{
    public class FirstPriceService : IMultibuyStrategy
    {
        public double Calculate(int NoOfItems, PricePlan ItemPricePlan)
        {
            if (NoOfItems == 0)
            {
                return 0;
            }

            double result = 0;

            if (ItemPricePlan.BulkItems != 0)
            {
                while (NoOfItems >= ItemPricePlan.BulkItems)
                {
                    result = result + ItemPricePlan.PriceOfBulk;
                    NoOfItems = NoOfItems - ItemPricePlan.BulkItems;
                }
            }
            return result + (ItemPricePlan.PriceSingle * NoOfItems);
        }
    }
}
