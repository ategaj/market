using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace market
{
    public partial class EditWindow : Window
    {
        public Product? NewProduct { get; private set; }

        public EditWindow()
        {
            InitializeComponent(); 
        } 
        private void changeButton(object sender, RoutedEventArgs e)
        {
            NewProduct = new Product
            {
                Name = NameTxt.Text,
                Price = int.TryParse(PriceTxt.Text, out int price)? price : 0,
                Count = int.TryParse(CountTxt.Text, out int count) ? count : 0,
                Description = DescTxt.Text,
                Image = (ProductImage.Source as BitmapImage)?.UriSource?.LocalPath
            };
            this.DialogResult = true;
        }
        private void UploadImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Изображения (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                ProductImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }
    }
}
