using System.Threading.Tasks;

namespace WpfApp.WindowsOld.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly CustomersViewModel _customersViewModel;

        private ViewModelBase _selectedViewModel;

        public ViewModelBase SelectedViewModel
        {
            get => _selectedViewModel;
            set 
            { 
                _selectedViewModel = value;
                NotifyPropertyChange();
            }
        }


        public MainViewModel(CustomersViewModel customersViewModel)
        {
            _selectedViewModel = customersViewModel;
        }

        public override async Task LoadAsync()
        {
            if (SelectedViewModel != null)
            {
               await SelectedViewModel.LoadAsync();
            }
        }
    }
}
