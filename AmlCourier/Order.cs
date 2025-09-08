namespace AmlCourier;

public class Order
{
    private readonly List<Parcel> Parcels = new();

    private bool _speedyShipping;

    private decimal _totalCost;

    public void AddParcel(Parcel parcel)
    {
        Parcels.Add(parcel);
    }

    public List<Parcel> GetParcels()
    {
        return Parcels;
    }

    public void EnableSpeedyShipping()
    {
        _speedyShipping = true;
    }

    public bool IsSpeedyShippingEnabled()
    {
        return _speedyShipping;
    }

    public decimal SetTotalCost(decimal cost)
    {
        return _totalCost = cost;
    }
    
    public decimal GetTotalCost()
    {
        return _totalCost;
    }
}