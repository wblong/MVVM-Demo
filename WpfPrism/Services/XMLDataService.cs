using System;
using System.Collections.Generic;
using WpfPrism.Models;
using System.IO;
using System.Xml.Linq;

namespace WpfPrism.Services
{
    class XMLDataService:IDataService
    {
        #region IDataService 成员
        public List<Models.Dish> GetAllDishes()
        {
            List<Dish> dishList = new List<Dish>();
            string xmlFile = Path.Combine(Environment.CurrentDirectory, @"Data\Data.xml");

            XDocument xDoc = XDocument.Load(xmlFile);
            var dishes = xDoc.Descendants("Dish");
            foreach (var d in dishes)
            {

                Dish dish = new Dish();
                dish.Name = d.Element("Name").Value;
                dish.Category = d.Element("Category").Value;
                dish.Comment = d.Element("Comment").Value;
                dish.Score = d.Element("Score").Value;
                dishList.Add(dish);
            }
            return dishList;
        }
#endregion
    }
}
