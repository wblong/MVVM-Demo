using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Prism.ViewModel;
using WpfPrism.Models;
using WpfPrism.Services;
using Microsoft.Practices.Prism.Commands;
using System.Windows;

namespace WpfPrism.ViewModels
{
    class MianWindowViewModel:NotificationObject
    {
        private Restaurant restaurant;
        public Restaurant Restaurant
        {
            get
            { return restaurant; }
            set
            {
                restaurant = value;
                RaisePropertyChanged("Restaurant");
            }
        }
        //外加一个属性
        private int count;
        public int Count
        {

            get { return count; }
            set
            {
                count = value;
                RaisePropertyChanged("Count");
            }
        }
        private List<DishMenuItemViewModel> dishMenu;
        public List<DishMenuItemViewModel> DishMenu
        {

            get { return dishMenu; }
            set
            {
                dishMenu = value;
                RaisePropertyChanged("DishMenu");
            }
        }
        public MianWindowViewModel()
        {

            LoadRestaurant();
            LoadDishMenu();

            PlaceOrderCommand = new DelegateCommand(new Action(PlaceOrderCommandExecute));
            SelectMenuItemCommand = new DelegateCommand(new Action(SelectMenuItemCommandExecute));
            
        }
        private void LoadRestaurant()
        {
            Restaurant = new Restaurant() { Name = "百年苏韵", Address = "江苏大学", PhoneNumber = "0511-12345678" };
        }
        private void LoadDishMenu()
        {
            DishMenu = new List<DishMenuItemViewModel>();
            IDataService ds = new XMLDataService();
            var dishes = ds.GetAllDishes();
            foreach (var d in dishes)
            {

                DishMenuItemViewModel item = new DishMenuItemViewModel() { Dish=d};
                DishMenu.Add(item);
            }
        }
        //两个命令属性
        public DelegateCommand PlaceOrderCommand { get; set; }
        public DelegateCommand SelectMenuItemCommand { get; set; }
        private void PlaceOrderCommandExecute()
        {
            var selectedDishes = dishMenu.Where(d => d.IsSelected == true).Select(d => d.Dish.Name).ToList();
            IOrderService orderService = new MockOrderService();
            orderService.PlaceOrder(selectedDishes);
            MessageBox.Show("订餐成功！");
        }
        private void SelectMenuItemCommandExecute()
        {
            Count = DishMenu.Count(n => n.IsSelected == true);
        }
    }
}
