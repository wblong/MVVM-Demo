using Microsoft.Practices.Prism.ViewModel;
using WpfPrism.Models;

namespace WpfPrism.ViewModels
{
    class DishMenuItemViewModel : NotificationObject
    {
        //菜单信息
        public Dish Dish { get; set; }
        //菜单选择按钮
        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = true;
                RaisePropertyChanged("IsSelected");
            }
        }
    }
}
