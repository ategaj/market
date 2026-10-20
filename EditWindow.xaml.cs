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
        private void valid(string[] strings)
        {
            for(int i = 0; i < strings.Length; i++)
            {
                if (string.IsNullOrEmpty(strings[i]))
                {
                    throw new Exception("Заполните поля!!!");
                }
            }
        }
        private void changeButton(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] s = { NameTxt.Text, PriceTxt.Text, CountTxt.Text, DescTxt.Text };
                valid(s);
                if (!int.TryParse(PriceTxt.Text, out int price) || !int.TryParse(CountTxt.Text, out int count))
                {
                    throw new Exception("Цена и количество должны быть числом!!!");
                }
                else if(price <= 0 || count <= 0)
                {
                    throw new Exception("Цена и количество не могут быть нулевыми или отрицательными!!!");
                }
                NewProduct = new Product
                {
                    Name = NameTxt.Text,
                    Price = price,
                    Count = count,
                    Description = DescTxt.Text,
                    Image = (ProductImage.Source as BitmapImage)?.UriSource?.LocalPath

                };
                this.DialogResult = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
