using ConsoleAppParcel2Go;

string json = File.ReadAllText("BulkPricePlans.json");
var servicepricelist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PricePlan>>(json);


IMultibuyStrategy firstPriceService = new FirstPriceService();
//Should the strategy change update it here with new version
//

ICheckout checkout = new Checkout(firstPriceService, servicepricelist);

bool done = false;
while (!done)
{
    Console.WriteLine("Scan an item or type T for Total, N to clear or X to close app ");
    string service = Console.ReadLine();

    switch (service)
    {
        case "T":
            Console.WriteLine(checkout.GetTotalPrice());
            break;
        case "N":
            checkout.Clear();
            Console.Clear();
            break;
        case "X":
            done = true;
            break;
        default:
            switch (servicepricelist.Select(x => x.Name).Contains(service) == true)
            {
                case true:
                    checkout.Scan(service);                    
                    break;
                default:
                    Console.WriteLine("Unknown service");
                    break;
            }            
            break;
    }   
} 


