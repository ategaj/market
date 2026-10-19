using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace market
{
    public class Product
    {
        public int Id;
        public string? Name;
        public int Price;
        public string? Description;
        public int Count;
        public String? Image;
        public Product() { }
        public Product(int id, string? name, int price, string? description, int count, String? image)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Description = description;
            this.Count = count;
            this.Image = image;
        }
    }
}
