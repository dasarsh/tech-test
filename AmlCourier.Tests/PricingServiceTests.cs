namespace AmlCourier.Tests;

public class PricingServiceTests
{
    [Theory]
    [InlineData(1, 1, 1, 1, 3)]
    [InlineData(49, 49, 49, 3, 8)]
    [InlineData(99, 99, 99, 6, 15)]
    [InlineData(100, 1, 1, 10, 25)]
    public void Order_Cost_With_Single_Parcel_Is_Calculated(int length, int width, int height, decimal weight, decimal expectedCost)
    {
        var order = new Order();
        order.AddParcel(new Parcel(length, width, height, weight));

        var costedOrder = PricingService.GetOrderCost(order);
        var actualCost = costedOrder.GetTotalCost();
        Assert.Equal(expectedCost, actualCost);
    }

    [Theory]
    [InlineData(1, 1, 1, 1, 6)]
    [InlineData(49, 49, 49, 3, 16)]
    [InlineData(99, 99, 99, 6, 30)]
    [InlineData(100, 1, 1, 10, 50)]
    public void Order_Cost_With_Single_Parcel_With_Speedy_Is_Calculated(int length, int width, int height, decimal weight, decimal expectedCost)
    {
        var order = new Order();
        order.AddParcel(new Parcel(length, width, height, weight));
        order.EnableSpeedyShipping();

        var costedOrder = PricingService.GetOrderCost(order);
        var actualCost = costedOrder.GetTotalCost();
        Assert.Equal(expectedCost, actualCost);
    }

    [Theory]
    [InlineData(1, 1, 1, 1, 6)]
    [InlineData(49, 49, 49, 3, 16)]
    [InlineData(99, 99, 99, 6, 30)]
    [InlineData(100, 1, 1, 10, 50)]
    public void Order_Cost_With_Multiple_Parcels_Is_Calculated(int length, int width, int height, decimal weight, decimal expectedCost)
    {
        var order = new Order();
        order.AddParcel(new Parcel(length, width, height, weight));
        order.AddParcel(new Parcel(length, width, height, weight));

        var costedOrder = PricingService.GetOrderCost(order);
        var actualCost = costedOrder.GetTotalCost();
        Assert.Equal(expectedCost, actualCost);
    }

    [Fact]
    public void Order_With_No_Parcels_Should_Cost_Zero()
    {
        var order = new Order();
        var costedOrder = PricingService.GetOrderCost(order);

        var actualCost = costedOrder.GetTotalCost();
        Assert.Equal(0m, actualCost);
    }
}