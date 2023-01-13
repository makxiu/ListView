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
using System.ComponentModel;

namespace ListView
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private MainWindow mainWindow = null;
        public Window1()
        {
            InitializeComponent();
        }
        public Window1(MainWindow mainWin)
        {
            InitializeComponent();
            mainWindow = mainWin;
            PrzygotujWiazanie();
        }
        private void PrzygotujWiazanie()
        {
            Produkt produktZListy = mainWindow.lstProdukty.SelectedItem as Produkt;
            if (produktZListy != null)
            {
                gridProdukt.DataContext = produktZListy;
            }
        }
        private void btnPotwierdz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
