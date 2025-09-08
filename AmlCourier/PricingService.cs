namespace AmlCourier;

public class PricingService
{
    public static Order GetOrderCost(Order order)
    {
        decimal totalCost = 0M;
        var parcels = order.GetParcels();

        foreach (var parcel in parcels)
        {
            totalCost += GetParcelCost(parcel);
        }

        if (order.IsSpeedyShippingEnabled()) {
            totalCost *= 2;
        }

        order.SetTotalCost(totalCost);

        return order;
    }

    public static decimal GetParcelCost(Parcel parcel)
    {
        var type = parcel.Type;
        return type switch
        {
            ParcelType.Small => 3M,
            ParcelType.Medium => 8M,
            ParcelType.Large => 15M,
            ParcelType.XL => 25M,
            _ => throw new ArgumentOutOfRangeException()
        };  
    }
}
