using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Appliances.data.Models
{
    public class StateDTO
    {
        public Guid Id { get; set; }
        public string StateName { get; set; }
        public string StateCode { get; set; }
    }
}