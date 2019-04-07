using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Appliances.data.Models.StoreManagement
{
    public class ExhibitorStoreDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string WebsiteURL { get; set; }
        public IList<ExhibitorAddressDTO> ExhibitorAddresses { get; set; }

        public ExhibitorStoreDTO()
        {
            ExhibitorAddresses = new List<ExhibitorAddressDTO>();
        }
    }
}