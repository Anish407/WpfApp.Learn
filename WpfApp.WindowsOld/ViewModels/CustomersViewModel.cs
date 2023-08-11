using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfApp.WindowsOld.Models;
using WpfApp.WindowsOld.Repository;

namespace WpfApp.WindowsOld.ViewModels
{
    public class CustomersViewModel : ViewModelBase
    {
        private readonly ICustomerRepository _customerRepository;
        private Customers selectedCustomer;

        public Customers SelectedCustomer 
        { 
            get => selectedCustomer; 
            set {
                selectedCustomer = value;
                NotifyPropertyChange();
            }
        }

        public CustomersViewModel(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public ObservableCollection<Customers> Customers { get; set; }
            = new ObservableCollection<Customers>();

        public async Task<ObservableCollection<Customers>> GetCustomersAsync()
        {
            if (Customers == null)
                return Customers;

            foreach (var item in await _customerRepository.GetCustomers())
                Customers.Add(item);

            return Customers;
        }

        public void Add(Customers customers)
        {
            Customers.Add(customers);
            SelectedCustomer = customers;
            
        }

    }
}
