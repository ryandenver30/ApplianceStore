using Appliances.Kernel.Modules.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances.Kernel.Framework.Modules.ProductManagement
{
    [Table("Products")]
    public class Product : MasterEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ModelNo { get; set; }
        public string Color { get; set; }
        public string Size { get; set;}
        public double Weight { get; set; }
        
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ProductSubCategory ProductSubCategory { get; set; }

        public Product()
        {

        }
        private Product(string name,string modelNo, string description, double price, string color, string size,double weight)
        {
            this.Name = name;
            this.ModelNo = modelNo;
            this.Description = description;
            this.Price = price;
            this.Color = color;
            this.Size = size;
            this.Weight = weight;
        }
        public Product Create(string name, string modelNo, string description, double price, string color, string size, double weight)
        {
            return new Product( name,  modelNo,  description,  price,  color,  size,  weight);
        }
        public void Update(string name, string modelNo, string description, double price, string color, string size, double weight)
        {
            this.Name = name;
            this.ModelNo = modelNo;
            this.Description = description;
            this.Price = price;
            this.Color = color;
            this.Size = size;
            this.Weight = weight;
        }
    }
}
