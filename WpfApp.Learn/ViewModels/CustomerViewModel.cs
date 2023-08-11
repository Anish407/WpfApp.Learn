using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp.Learn.Models;

namespace WpfApp.Learn.ViewModels
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        private Customer selectedCustomer;

        public Customer SelectedCustomer { 
            get => selectedCustomer;
            set 
            { 
                selectedCustomer = value;
                NotifyChange();
            }
        }
        public ObservableCollection<Customer> Customers { get; set; }
            = new ObservableCollection<Customer>();

        public event PropertyChangedEventHandler? PropertyChanged;

        public async  Task GetCustomersAsync()
        {
            await Task.Delay(100);
            Customers.Add(new Customer
            {
                FirstName = "Anish",
                Id = 1,
                IsDeveloper = true,
                LastName = "Aravind"
            });
            Customers.Add(new Customer
            {
                FirstName = "Vipin",
                Id = 2,
                IsDeveloper = false,
                LastName = "V"
            });
            Customers.Add(new Customer
            {
                FirstName = "Libu",
                Id = 3,
                IsDeveloper = true,
                LastName = "Mathew"
            });
        }

        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
            SelectedCustomer = customer;
        }

        public void NotifyChange([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
