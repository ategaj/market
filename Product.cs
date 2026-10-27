using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace market
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
        public int Count { get; set; }
        public string? Image { get; set; }
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
