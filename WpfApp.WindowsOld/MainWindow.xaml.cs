using System;
using System.Windows;
using WpfApp.WindowsOld.Repository;
using WpfApp.WindowsOld.ViewModels;

namespace WpfApp.WindowsOld
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;

        public MainWindow()
        {
            _viewModel= new MainViewModel(new CustomersViewModel(new CustomerRepository()));
            DataContext = _viewModel;
            Loaded += MainWindowLoad;
            InitializeComponent();
        }

        private async void MainWindowLoad(object sender, RoutedEventArgs e)
        {
           await _viewModel.LoadAsync();
        }

     
    }
}
