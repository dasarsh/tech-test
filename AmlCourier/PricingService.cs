namespace AmlCourier;

public class PricingService
{
    public static decimal GetCost(int length, int width, int height)
    {
        if (length < 10 && width < 10 && height < 10)
        {
            return 3M;
        }

        if (length < 50 && width < 50 && height < 50)
        {
            return 8M;
        }

        if (length < 100 && width < 100 && height < 100)
        {
            return 15M;
        }

        return 25M;
    }
}
