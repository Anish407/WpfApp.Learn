using System.Collections.ObjectModel;
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
        public DelegateCommand DeleteCommand { get; }

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

        public bool IsCustomerSelected => SelectedCustomer != null;


        public CustomerItemViewModel SelectedCustomer
        {
            get => selectedCustomer;
            set
            {
                selectedCustomer = value;
                NotifyPropertyChange();
                DeleteCommand.RaiseExecuteChangedEvent();
                NotifyPropertyChange(nameof(IsCustomerSelected));
            }
        }

        public CustomersViewModel(ICustomerRepository customerRepository)
        {
            AddCommand = new DelegateCommand(Add);
            MoveGridCommand = new DelegateCommand(MoveGrid);
            // this will register the candelete delegate
            // and will call the registered delegate CanDelete() in this class
            DeleteCommand = new DelegateCommand(Delete, CanDelete);
            _customerRepository = customerRepository;
        }

        private bool CanDelete(object arg) => SelectedCustomer != null;


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

        public void Delete(object parameter)
        {
            Customers.Remove(SelectedCustomer);
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

        public override async Task LoadAsync()
        {
            Customers = await GetCustomersAsync();
        }

    }
}
