using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Appliances.data.Models
{
    public class CountryDTO 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string CountryPhoneCode { get; set; }
    }
}