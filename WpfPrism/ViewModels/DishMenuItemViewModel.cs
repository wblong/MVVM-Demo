using Microsoft.Practices.Prism.ViewModel;
using WpfPrism.Models;

namespace WpfPrism.ViewModels
{
    class DishMenuItemViewModel : NotificationObject
    {
        public Dish Dish { get; set; }

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
