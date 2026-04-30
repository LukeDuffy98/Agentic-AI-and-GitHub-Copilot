using StoreApp;

var sampleOrder = new List<OrderItem>
{
    new("Notebook", 12.50m, 2),
    new("Pen Set", 5.00m, 1)
};

var calculator = new OrderCalculator();

Console.WriteLine("StoreApp sample order");
Console.WriteLine(calculator.BuildOrderSummary(sampleOrder, isLoyaltyMember: true));
