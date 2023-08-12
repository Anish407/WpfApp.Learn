using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.WindowsOld.Models;
using WpfApp.WindowsOld.Repository;
using WpfApp.WindowsOld.ViewModels;

namespace WpfApp.WindowsOld.Controls
{
    /// <summary>
    /// Interaction logic for CustomerDetailsControl.xaml
    /// </summary>
    public partial class CustomerDetailsControl : UserControl
    {
        public CustomersViewModel CustomerViewModel { get; set; }

        public CustomerDetailsControl()
        {
            CustomerViewModel = new CustomersViewModel(new CustomerRepository());  
            DataContext = CustomerViewModel;
            Loaded += LoadCustomers;
            InitializeComponent();
        }

        private async void LoadCustomers(object sender, RoutedEventArgs e)
        {
           await CustomerViewModel.GetCustomersAsync();
        }

        //private void MoveGrid(object sender, RoutedEventArgs e)
        //{
        //    CustomerViewModel.MoveGrid();
        //    //var column = Grid.GetColumn(CustomerListView);

        //    //var newColumn = column == 0 ? 2 : 0;
        //    //Grid.SetColumn(CustomerListView, newColumn);
        //}

        //private void Add_Customer_Click(object sender, RoutedEventArgs e)
        //{
        //    Customers customers = new Customers
        //    {
        //        FirstName = "New Customer",
        //        Id = 5,
        //        IsDeveloper = false,
        //        LastName = "Demo"
        //    };
        //    CustomerViewModel.Add(new CustomerItemViewModel(customers));
           
        //}
    }
}
