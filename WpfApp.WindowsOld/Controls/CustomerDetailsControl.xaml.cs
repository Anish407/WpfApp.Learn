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

namespace WpfApp.WindowsOld.Controls
{
    /// <summary>
    /// Interaction logic for CustomerDetailsControl.xaml
    /// </summary>
    public partial class CustomerDetailsControl : UserControl
    {
        public CustomerDetailsControl()
        {
            InitializeComponent();
        }

        private void MoveGrid(object sender, RoutedEventArgs e)
        {
            var column = Grid.GetColumn(CustomerListView);

            var newColumn = column == 0 ? 2 : 0;
            Grid.SetColumn(CustomerListView, newColumn);
        }
    }
}
