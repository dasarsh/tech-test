namespace AmlCourier.Tests;

public class ParcelTests
{
    [Theory]
    [InlineData(-1, 1, 1, 1)]
    [InlineData(1, -1, 1, 1)]
    [InlineData(1, 1, -1, 1)]
    [InlineData(1, 1, 1, -1)]
    public void Parcel_Should_Throw_When_Dimensions_Are_Invalid(int length, int width, int height, decimal weight)
    {
        Assert.Throws<ArgumentException>(() => new Parcel(length, width, height, weight));
    }
    
    [Theory]
    [InlineData(1, 1, 1, -1)]
    public void Parcel_Should_Throw_When_Weight_Is_Invalid(int length, int width, int height, decimal weight)
    {
        Assert.Throws<ArgumentException>(() => new Parcel(length, width, height, weight));
    }
}