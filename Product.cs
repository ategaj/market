using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace market
{
    internal class Product
    {
        int Id;
        string? Name;
        int price;
        string? description;
        int count;
        Image? image;

        public Product(int Id, string? Name, int price, string? description, int count, Image? image)
        {
            this.Id = Id;
            this.Name = Name;
            this.price = price;
            this.description = description;
            this.count = count;
            this.image = image;
        }
    }
}
