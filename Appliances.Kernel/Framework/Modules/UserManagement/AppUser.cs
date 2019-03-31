using Appliances.Kernel.Modules.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances.Kernel.Framework.Modules.UserManagement
{
    public class AppUser : MasterEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string PhoneNo { get; set; }
        public string Password { get; set; }

        public AppUser()
        {

        }

        private AppUser(string firstName,string lastName,string emailId,string phoneNo,string password)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmailId = emailId;
            this.PhoneNo = phoneNo;
        }
        public static AppUser Create(string firstName, string lastName, string emailId, string phoneNo, string password)
        {
            return new AppUser( firstName,  lastName,  emailId,  phoneNo, password);
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
