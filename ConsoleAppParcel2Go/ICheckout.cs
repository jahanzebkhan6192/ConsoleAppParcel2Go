interface ICheckout
{
    void Scan(string service); // Adds a service to the checkout
    double GetTotalPrice(); // Calculates the total price, applying the best discount option
    void Clear();//removes all services
}