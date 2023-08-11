using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.Learn.ViewModels;

namespace WpfApp.Learn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public CustomerViewModel _CustomerViewModel { get; set; }= new ();
        public MainWindow()
        {
            Loaded += PageLoad;
            DataContext = _CustomerViewModel;
            InitializeComponent();
        }

        private async  void PageLoad(object sender, RoutedEventArgs e)
        {
            await _CustomerViewModel.GetCustomersAsync();
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            _CustomerViewModel.AddCustomer(new Models.Customer
            {
                FirstName = "New Customer",
                Id = 5,
                IsDeveloper = false,
                LastName = "Demo"
            });
        }
    }
}