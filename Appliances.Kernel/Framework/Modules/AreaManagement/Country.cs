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
    [Table("Country")]
    public class Country : MasterEntity
    {
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string CountryPhoneCode { get; set; }

        public Country()
        {

        }
        private static void Validate(string name)
        {
            if (String.IsNullOrEmpty(name))
                throw new ValidationException("Invalid Category Name");
        }
        public Country(string name,string code,string phoneCode) : this()
        {
            Validate(name);
            this.CountryName = name;
            this.CountryCode = code;
            this.CountryPhoneCode = phoneCode;
        }
        public static Country Create(string name, string code, string phoneCode)
        {
            return new Country(name, code, phoneCode);
        }

        public void Update(string name, string code, string phoneCode)
        {
            Validate(name);
            this.CountryName = name;
            this.CountryCode = code;
            this.CountryPhoneCode = phoneCode;
        }
    }
}
