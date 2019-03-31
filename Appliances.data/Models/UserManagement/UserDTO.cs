using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Appliances.data.Models.UserManagement
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string PhoneNo { get; set; }
        public string Password { get; set; }
    }
}