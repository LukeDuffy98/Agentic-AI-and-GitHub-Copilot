using System.Text;

namespace StoreApp;

public sealed class OrderCalculator
{
    public decimal CalculateSubtotal(IEnumerable<OrderItem> items)
    {
        ArgumentNullException.ThrowIfNull(items);

        return items.Sum(item => item.UnitPrice * item.Quantity);
    }

    public decimal CalculateDiscount(decimal subtotal, bool isLoyaltyMember)
    {
        if (subtotal < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(subtotal));
        }

        if (!isLoyaltyMember || subtotal < 100m)
        {
            return 0m;
        }

        return subtotal * 0.05m;
    }

    public decimal CalculateShipping(decimal subtotal)
    {
        if (subtotal < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(subtotal));
        }

        if (subtotal >= 50m)
        {
            return 0m;
        }

        return 9.99m;
    }

    public decimal CalculateFinalTotal(IEnumerable<OrderItem> items, bool isLoyaltyMember)
    {
        ArgumentNullException.ThrowIfNull(items);

        var subtotal = CalculateSubtotal(items);
        var discount = CalculateDiscount(subtotal, isLoyaltyMember);
        var shipping = CalculateShipping(subtotal);

        return subtotal - discount + shipping;
    }

    public string FormatPackingSlip(IEnumerable<OrderItem> items)
    {
        // LAB TODO: Part 3 asks students to implement this method.
        throw new NotImplementedException();
    }

    public string BuildOrderSummary(IEnumerable<OrderItem> items, bool isLoyaltyMember)
    {
        ArgumentNullException.ThrowIfNull(items);

        var orderItems = items.ToList();
        var subtotal = CalculateSubtotal(orderItems);
        var discount = CalculateDiscount(subtotal, isLoyaltyMember);
        var shipping = CalculateShipping(subtotal);
        var total = subtotal - discount + shipping;

        var summary = new StringBuilder();
        summary.AppendLine("Order summary");
        summary.AppendLine($"Items: {orderItems.Count}");
        summary.AppendLine($"Subtotal: {subtotal:C}");
        summary.AppendLine($"Discount: {discount:C}");
        summary.AppendLine($"Shipping: {shipping:C}");
        summary.AppendLine($"Total: {total:C}");

        foreach (var item in orderItems)
        {
            summary.AppendLine($" - {item.Name} x{item.Quantity}");
        }

        return summary.ToString().TrimEnd();
    }
}
