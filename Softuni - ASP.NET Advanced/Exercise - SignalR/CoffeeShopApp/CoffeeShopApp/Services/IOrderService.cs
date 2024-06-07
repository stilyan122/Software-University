namespace CoffeeShopApp.Services
{
    using CoffeeShopApp.Models;

    public interface IOrderService
    {
        int NewOrder();

        CheckResult GetUpdate(int orderId);
    }
}
