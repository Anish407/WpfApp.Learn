using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfApp.WindowsOld.Enums;
using WpfApp.WindowsOld.Models;
using WpfApp.WindowsOld.Repository;

namespace WpfApp.WindowsOld.ViewModels
{
    public class CustomersViewModel : ViewModelBase
    {
        private readonly ICustomerRepository _customerRepository;
        private CustomerItemViewModel selectedCustomer;
        private GridSide gridRowSide = GridSide.Left;

        public GridSide GridRowSide 
        { 
            get => gridRowSide;
            set 
            {
                gridRowSide = value;
                NotifyPropertyChange();
            }
        }

        public CustomerItemViewModel SelectedCustomer 
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
        public ObservableCollection<CustomerItemViewModel> Customers { get; set; }
            = new ObservableCollection<CustomerItemViewModel>();

        public async Task<ObservableCollection<CustomerItemViewModel>> GetCustomersAsync()
        {
            if (Customers == null)
                return Customers;

            foreach (var item in await _customerRepository.GetCustomers())
                Customers.Add(new CustomerItemViewModel(item));

            return Customers;
        }

        public void MoveGrid()
        {
            GridRowSide= GridRowSide == GridSide.Left ? GridSide.Right : GridSide.Left;
        }

        public void Add(CustomerItemViewModel customers)
        {
            Customers.Add(customers);
            SelectedCustomer = customers;
        }

    }
}
