namespace AmlCourier.Tests;

public class PricingServiceTests
{
    [Theory]
    [InlineData(1, 1, 1, 3)]
    [InlineData(49, 49, 49, 8)]
    [InlineData(99, 99, 99, 15)]
    [InlineData(100, 1, 1, 25)]
    public void Order_Cost_With_Single_Parcels_Is_Calculated(int length, int width, int height, decimal expectedCost)
    {
        var order = new List<Parcel>
        {
            new Parcel(length, width, height),
        };

        var cost = PricingService.GetOrderCost(order);
        Assert.Equal(expectedCost, cost);
    }

    [Theory]
    [InlineData(1, 1, 1, 6)]
    [InlineData(49, 49, 49, 16)]
    [InlineData(99, 99, 99, 30)]
    [InlineData(100, 1, 1, 50)]
    public void Order_Cost_With_Multiple_Parcels_Is_Calculated(int length, int width, int height, decimal expectedCost)
    {
        var order = new List<Parcel>
        {
            new Parcel(length, width, height),
            new Parcel(length, width, height),
        };

        var cost = PricingService.GetOrderCost(order);
        Assert.Equal(expectedCost, cost);
    }

    [Fact]
    public void Order_With_No_Parcels_Should_Cost_Zero()
    {
        var order = new List<Parcel>();
        var cost = PricingService.GetOrderCost(order);

        Assert.Equal(0m, cost);
    }
}