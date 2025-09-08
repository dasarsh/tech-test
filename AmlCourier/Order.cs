namespace AmlCourier;

public class Order
{
    private readonly List<Parcel> Parcels = new();

    private bool _speedyShipping;
    
    private decimal _speedyShippingCost;

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

    public void SetTotalCost(decimal cost)
    {
        _totalCost = _speedyShipping ? cost * 2 : cost;
        _speedyShippingCost = _speedyShipping ? cost : 0;
    }

    public decimal GetTotalCost()
    {
        return _totalCost;
    }
    
    public decimal GetSpeedyShippingCost()
    {
        return _speedyShippingCost;
    }
}