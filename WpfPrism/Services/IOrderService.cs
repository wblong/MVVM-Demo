using System.Collections.Generic;
namespace WpfPrism.Services
{
    interface IOrderService
    {
        void PlaceOrder(List<string> dishes);
    }
}
