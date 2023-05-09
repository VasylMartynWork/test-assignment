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
using System.Windows.Shapes;

namespace TestAssignment
{
    /// <summary>
    /// Interaction logic for CurrencyInformationWindow.xaml
    /// </summary>
    public partial class CurrencyInformationWindow : Window
    {
        public CurrencyInformationWindow()
        {
            InitializeComponent();

            DataContext = new CurrencyInformationViewModel();
        }
    }
}
