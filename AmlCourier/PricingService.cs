namespace AmlCourier;

public class PricingService
{
    private const decimal OverweightChargePerKg = 1m;
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

        decimal baseCost = type switch
        {
            ParcelType.Heavy  => 50m,
            ParcelType.Small  => 3m,
            ParcelType.Medium => 8m,
            ParcelType.Large  => 15m,
            ParcelType.XL     => 25m,
            _ => throw new ArgumentOutOfRangeException("Unknown category")
        };

        var overweightKg = Math.Max(0, weight - 50m);
        var surcharge = overweightKg * OverweightChargePerKg;

        return baseCost + surcharge;
    }
}
