using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using Path = System.IO.Path;
namespace market
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public Product? NewProduct { get; private set; }
        public UserControl1()
        {
            InitializeComponent();
        }
            private void valid(string[] strings)
            {
                for (int i = 0; i < strings.Length; i++)
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
                    else if (price <= 0 || count <= 0)
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            private void UploadImage_Click(object sender, RoutedEventArgs e)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Изображение (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                if (openFileDialog.ShowDialog() == true)
                {
                    string h = openFileDialog.FileName;
                    string imagesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", Path.GetFileName(h));
                    Directory.CreateDirectory(Path.GetDirectoryName(imagesPath));
                    File.Copy(openFileDialog.FileName, imagesPath, true);
                    ProductImage.Source = new BitmapImage(new Uri(imagesPath));
                }
            }
        }
    }

