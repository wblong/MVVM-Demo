using System.Collections.Generic;
using WpfPrism.Models;
namespace WpfPrism.Services
{
    interface IDataService
    {
        List<Dish> GetAllDishes();
    }
}
