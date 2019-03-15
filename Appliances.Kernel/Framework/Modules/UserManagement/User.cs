using Appliances.Kernel.Modules.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances.Kernel.Framework.Modules.UserManagement
{
    public class User : MasterEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string PhoneNo { get; set; }
        public string Password { get; set; }

        public User()
        {

        }

        private User(string firstName,string lastName,string emailId,string phoneNo,string password)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmailId = emailId;
            this.PhoneNo = phoneNo;
        }
        public User Create(string firstName, string lastName, string emailId, string phoneNo, string password)
        {
            return new User( firstName,  lastName,  emailId,  phoneNo, password);
        }
        public void Update(string firstName, string lastName, string emailId, string phoneNo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmailId = emailId;
            this.PhoneNo = phoneNo;
        }
    }
}
