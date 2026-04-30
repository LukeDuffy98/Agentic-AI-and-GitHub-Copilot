using StoreApp;

namespace StoreApp.Tests;

public sealed class OrderCalculatorTests
{
    private readonly OrderCalculator _calculator = new();

    [Fact]
    public void CalculateSubtotal_ReturnsCombinedItemCost()
    {
        var items = CreateSampleItems();

        var subtotal = _calculator.CalculateSubtotal(items);

        Assert.Equal(40.00m, subtotal);
    }

    [Fact]
    public void CalculateFinalTotal_AddsShippingWhenOrderIsBelowFreeShippingThreshold()
    {
        var items = CreateSampleItems();

        var total = _calculator.CalculateFinalTotal(items, isLoyaltyMember: false);

        Assert.Equal(49.99m, total);
    }

    [Fact]
    public void BuildOrderSummary_IncludesHeadlineAndItemNames()
    {
        var items = CreateSampleItems();

        var summary = _calculator.BuildOrderSummary(items, isLoyaltyMember: false);

        Assert.Contains("Order summary", summary);
        Assert.Contains("Notebook", summary);
        Assert.Contains("Pen Set", summary);
    }

    [Fact(Skip = "Lab step: remove Skip in Part 4, then fix the discount bug.")]
    public void CalculateDiscount_GivesTenPercentDiscountToLargeLoyaltyOrders()
    {
        var items = new[]
        {
            new OrderItem("Desk Lamp", 120m, 1)
        };

        var subtotal = _calculator.CalculateSubtotal(items);
        var discount = _calculator.CalculateDiscount(subtotal, isLoyaltyMember: true);

        Assert.Equal(12m, discount);
    }

    [Fact(Skip = "Lab step: remove Skip in Part 3 after implementing FormatPackingSlip.")]
    public void FormatPackingSlip_ReturnsOneLinePerItem()
    {
        var items = CreateSampleItems();

        var slip = _calculator.FormatPackingSlip(items);

        Assert.Contains("Packing slip", slip);
        Assert.Contains("1. Notebook x2", slip);
        Assert.Contains("2. Pen Set x1", slip);
    }

    private static OrderItem[] CreateSampleItems()
    {
        return
        [
            new OrderItem("Notebook", 12.50m, 2),
            new OrderItem("Pen Set", 5.00m, 1),
            new OrderItem("Water Bottle", 5.00m, 2)
        ];
    }
}