namespace AmlCourier.Tests;

public class PricingServiceTests
{
    [Theory]
    [InlineData(1, 1, 1, 3)]
    [InlineData(49, 49, 49, 8)]
    [InlineData(99, 99, 99, 15)]
    [InlineData(100, 1, 1, 25)]
    public void Test1(int length, int width, int height, decimal expectedCost)
    {
        var order = new List<Parcel>
        {
            new Parcel(length, width, height),
        };

        var cost = PricingService.GetOrderCost(order);
        Assert.Equal(expectedCost, cost);
    }
}