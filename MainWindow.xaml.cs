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
                products.Add(editWindow.NewProduct);
            }
        }

        private void DelButton(object sender, RoutedEventArgs e)
        {
            Product s = (Product)ProductListBox.SelectedItem;
            products.Remove(s);
        }

        private void ChangeButton(object sender, RoutedEventArgs e)
        {
            Product selected = (Product)ProductListBox.SelectedItem;
            if ( selected != null)
            {
                EditWindow editWindow = new EditWindow();
                editWindow.edit.Content = "Изменить";
                editWindow.NameTxt.Text = selected.Name;
                editWindow.PriceTxt.Text = selected.Price.ToString();
                editWindow.CountTxt.Text = selected.Count.ToString();
                editWindow.DescTxt.Text = selected.Description;
                editWindow.ProductImage.Source = new BitmapImage(new Uri(selected.Image));
                if (editWindow.ShowDialog() == true && editWindow.NewProduct != null)
                {
                    selected.Name = editWindow.NewProduct.Name;
                    selected.Price = editWindow.NewProduct.Price;
                    selected.Count = editWindow.NewProduct.Count;
                    selected.Description = editWindow.NewProduct.Description;
                    selected.Image = editWindow.NewProduct.Image;

                    ProductListBox.Items.Refresh();
                }
            }
        }
    }
}

