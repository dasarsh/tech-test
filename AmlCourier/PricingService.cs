namespace AmlCourier;

public class PricingService
{
    public static decimal GetOrderCost(List<Parcel> parcels)
    {
        decimal totalCost = 0M;
        foreach (var parcel in parcels)
        {
            totalCost += GetParcelCost(parcel);
        }
        return totalCost;
    }

    public static decimal GetParcelCost(Parcel parcel)
    {
        if (parcel.LengthCm < 10 && parcel.WidthCm < 10 && parcel.HeightCm < 10)
        {
            return 3M;
        }

        if (parcel.LengthCm < 50 && parcel.WidthCm < 50 && parcel.HeightCm < 50)
        {
            return 8M;
        }

        if (parcel.LengthCm < 100 && parcel.WidthCm < 100 && parcel.HeightCm < 100)
        {
            return 15M;
        }

        return 25M;
    }
}
