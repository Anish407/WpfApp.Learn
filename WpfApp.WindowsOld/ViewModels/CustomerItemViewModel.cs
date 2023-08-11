using WpfApp.WindowsOld.Models;

namespace WpfApp.WindowsOld.ViewModels
{
    public class CustomerItemViewModel:ViewModelBase
    {
        private readonly Customers _customer;

        public CustomerItemViewModel(Customers customers)
        {
           _customer = customers;
        }

        public int Id => _customer.Id;
        public string FirstName 
        { 
            get => _customer.FirstName; 
            set
            {
                 _customer.FirstName = value ;
                NotifyPropertyChange();
            }
        }
        public string LastName
        {
            get => _customer.LastName;
            set
            {
                _customer.LastName = value;
                NotifyPropertyChange();
            }
        }
        public bool IsDeveloper
        {
            get => _customer.IsDeveloper;
            set
            {
                 _customer.IsDeveloper = value;
                NotifyPropertyChange();
            }
        }
    }
}
