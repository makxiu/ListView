using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ListView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Produkt> ListaProduktow = null;

        private void przygotujWiazanie()
        {
            ListaProduktow = new ObservableCollection<Produkt>();
            ListaProduktow.Add(new Produkt("001", "przedmiot1", 8121, "magazyn 2"));
            ListaProduktow.Add(new Produkt("002", "przedmiot2", 3137, "magazyn 1"));
            ListaProduktow.Add(new Produkt("003", "Przedmiot3", 42135, "magazyn 2"));
            ListaProduktow.Add(new Produkt("004", "Przedmiot4", 336, "magazyn 1"));
            ListaProduktow.Add(new Produkt("005", "przedmiot5", 4332, "magazyn 3"));
            lstProdukty.ItemsSource = ListaProduktow;

            CollectionView widok = (CollectionView)CollectionViewSource.GetDefaultView(lstProdukty.ItemsSource);
            widok.SortDescriptions.Add(new SortDescription("Magazyn", ListSortDirection.Ascending));
            widok.SortDescriptions.Add(new SortDescription("Nazwa", ListSortDirection.Descending));

            widok.Filter = FiltrUzytkownika;
        }
        private bool FiltrUzytkownika(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as Produkt).Nazwa.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lstProdukty.ItemsSource).Refresh();
        }
        public MainWindow()
        {
            InitializeComponent();
            przygotujWiazanie();
        }

        private void lstProdukty_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Window1 okno1 = new Window1(this);
            okno1.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Produkt produktZListy = lstProdukty.SelectedItem as Produkt;

            MessageBoxResult odpowiedz = MessageBox.Show("Czy usunac produkt: " + produktZListy.Nazwa.ToString() + " "+ produktZListy.Symbol.ToString() + "?", "Pytanie", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if(odpowiedz==MessageBoxResult.Yes) ListaProduktow.Remove(produktZListy);
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            ListaProduktow.Add(new Produkt(SymbolDod.Text, ProdDod.Text, int.Parse(LiczbaDod.Text), MagazynDod.Text));
        }
    }
}
