namespace AmlCourier;

public class Parcel
{
    public int LengthCm { get; }
    public int WidthCm { get; }
    public int HeightCm { get; }

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
}