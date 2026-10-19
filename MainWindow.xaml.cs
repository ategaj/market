using System.Collections.ObjectModel;
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
using market;

namespace market
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> products { get; set; } = new();
        public MainWindow()
        {
            InitializeComponent();
            ProductListBox.ItemsSource = products;
        }

        private void AddButton(object sender, RoutedEventArgs e)
        {
            EditWindow editWindow = new EditWindow();
            editWindow.edit.Content = "Добавить";
            if (editWindow.ShowDialog() == true && editWindow.NewProduct != null)
            {
                editWindow.NewProduct.Id = products.Count == 0 ? 1 : products.Max(p => p.Id) + 1;
                products.Add(editWindow.NewProduct);
            }
        }

        private void DelButton(object sender, RoutedEventArgs e)
        {

        }

        private void ChangeButton(object sender, RoutedEventArgs e)
        {
            EditWindow editWindow = new EditWindow();
            editWindow.edit.Content = "Изменить";
            editWindow.ShowDialog();
        }
    }
}