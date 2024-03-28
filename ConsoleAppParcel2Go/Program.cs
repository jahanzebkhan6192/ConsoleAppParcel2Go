using ConsoleAppParcel2Go;

string json = File.ReadAllText("BulkPricePlans.json");
var servicepricelist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PricePlan>>(json);

ServiceProduct serviceProduct = new ServiceProduct();
Checkout checkout = new Checkout(serviceProduct, servicepricelist);

do
{
    Console.WriteLine("Scan an item or type T for Total, N to clear or X to close app ");
    string service = Console.ReadLine();
    if (service.ToUpper() == "T")
        Console.WriteLine(checkout.GetTotalPrice());
    else if (service.ToUpper() == "N")
    {
        checkout.Clear();
        Console.Clear();
    }
    else if (service.ToUpper() == "X")
        break;
    else if (servicepricelist.Select(x => x.Name).Contains(service))
        checkout.Scan(service);
    else
        Console.WriteLine("Unknown service");

} while (true);


