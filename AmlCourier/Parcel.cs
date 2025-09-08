namespace AmlCourier;

public class Parcel
{
    public int LengthCm { get; }
    public int WidthCm { get; }
    public int HeightCm { get; }
    public ParcelType Type { get; set; }

    public Parcel(int lengthCm, int widthCm, int heightCm)
    {
        if (lengthCm <= 0 || widthCm <= 0 || heightCm <= 0)
        {
            throw new ArgumentException("Dimensions must be positive");
        }

        LengthCm = lengthCm;
        WidthCm = widthCm;
        HeightCm = heightCm;
    }

    private void SetType()
    {
        if (LengthCm < 10 && WidthCm < 10 && HeightCm < 10)
        {
            Type = ParcelType.Small;
        }
        else if (LengthCm < 50 && WidthCm < 50 && HeightCm < 50)
        {
            Type = ParcelType.Medium;
        }
        else if (LengthCm < 100 && WidthCm < 100 && HeightCm < 100)
        {
            Type = ParcelType.Large;
        }
        else
        {
            Type = ParcelType.XL;
        }
    }
}