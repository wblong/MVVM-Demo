using System.Collections.Generic;
using System.IO;

namespace WpfPrism.Services
{
    class MockOrderService:IOrderService
    {
#region IOrderService 成员
        public void PlaceOrder(List<string> dishes)
        {
            File.WriteAllLines(@"order.txt", dishes.ToArray());
        }
#endregion
    }
}
