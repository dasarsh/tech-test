namespace AmlCourier;

public class PricingService
{
    private const decimal OverweightChargePerKg = 2m;
    public static Order GetOrderCost(Order order)
    {
        decimal totalCost = 0M;
        var parcels = order.GetParcels();

        foreach (var parcel in parcels)
        {
            totalCost += GetParcelCost(parcel);
        }

        order.SetTotalCost(totalCost);

        return order;
    }
    
    public static decimal GetParcelCost(Parcel parcel)
    {
        var type = parcel.Type;
        var weight = parcel.WeightKg;

        (decimal baseCost, decimal weightLimit) = type switch
        {
            ParcelType.Small  => (3m, 1m),
            ParcelType.Medium => (8m, 3m),
            ParcelType.Large  => (15m, 6m),
            ParcelType.XL     => (25m, 10m),
            _ => throw new ArgumentOutOfRangeException("Unknown category")
        };

        var overweightKg = Math.Max(0, weight - weightLimit);
        var surcharge = overweightKg * OverweightChargePerKg;

        return baseCost + surcharge;
    }
}
