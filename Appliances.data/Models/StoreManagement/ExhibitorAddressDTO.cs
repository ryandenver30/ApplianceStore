using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;

namespace Appliances.data.Models.StoreManagement
{
    public class ExhibitorAddressDTO
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public string PhoneNo { get; set; }
        public string OfficeNo { get; set; }
        public string ExhibitorName { get; set; }
        public string EmailId { get; set; }
        public string Location { get; set; }
        public CountryDTO Country { get; set; }
        public StateDTO State { get; set; }

    }
}