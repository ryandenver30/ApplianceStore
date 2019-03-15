using Appliances.Kernel.Modules.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances.Kernel.Framework.Modules
{
    [Table("City")]
    public class City : MasterEntity
    {
        public string CityName { get; set; }
        public string ZipCode { get; set; }
        [Column("StateId")]
        public virtual State State { get; set; }

        public City()
        {

        }
        private static void Validate(string name)
        {
            if (String.IsNullOrEmpty(name))
                throw new ValidationException("Invalid Category Name");
        }
        public City(string cityName, string zipcode)
        {
            Validate(cityName);
            this.CityName = cityName;
            this.ZipCode = zipcode;
        }
        public static State Create(string cityName, string zipcode)
        {
            return new State(cityName, zipcode);
        }
        public void Update(string cityName, string zipcode)
        {
            Validate(cityName);
            this.CityName = cityName;
            this.ZipCode = zipcode;
        }
    }
}
