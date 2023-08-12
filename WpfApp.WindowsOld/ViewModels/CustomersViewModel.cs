using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfApp.WindowsOld.Commands;
using WpfApp.WindowsOld.Enums;
using WpfApp.WindowsOld.Models;
using WpfApp.WindowsOld.Repository;

namespace WpfApp.WindowsOld.ViewModels
{
    public class CustomersViewModel : ViewModelBase
    {
        public DelegateCommand AddCommand { get; }
        public DelegateCommand MoveGridCommand { get; }

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
            set
            {
                selectedCustomer = value;
                NotifyPropertyChange();
            }
        }

        public CustomersViewModel(ICustomerRepository customerRepository)
        {
            AddCommand = new DelegateCommand(Add);
            MoveGridCommand = new DelegateCommand(MoveGrid);
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

        public void MoveGrid(object parameter)
        {
            GridRowSide = GridRowSide == GridSide.Left ? GridSide.Right : GridSide.Left;
        }

        public void Add(object parameter)
        {
            CustomerItemViewModel customers = new CustomerItemViewModel(new Customers
            {
                FirstName = "New Customer",
                Id = 5,
                IsDeveloper = false,
                LastName = "Demo"
            });
            Customers.Add(customers);
            SelectedCustomer = customers;
        }

    }
}
