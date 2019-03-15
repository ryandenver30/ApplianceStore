﻿using Appliances.Kernel.Modules.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances.Kernel.Framework.Modules.StoreManagement
{
    [Table("EXHIBITORADDRESS")]
    public class ExhibitorAddress : MasterEntity
    {
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public string PhoneNo { get; set; }
        public string OfficeNo { get; set; }
        public string ExhibitorName { get; set; }
        public string EmailId { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }

        public virtual Country Country { get; set; }
        public virtual State State { get; set; }
        public virtual ExhibitorStore Exhibitor { get; set; }

        public ExhibitorAddress()
        {
        }

        public ExhibitorAddress(string address, int zipcode, string phoneNo, string officeNo, string exhibitorName, string emailId) : this()
        {
            Validate(address, zipcode, phoneNo, officeNo, exhibitorName, emailId);
            this.Address = address;
            this.ZipCode = zipcode;
            this.PhoneNo = phoneNo;
            this.OfficeNo = officeNo;
            this.ExhibitorName = exhibitorName;
            this.EmailId = emailId;
        }

        private static void Validate(string address, int zipcode, string phoneNo, string officeNo, string exhibitorName, string emailId)
        {
            if (String.IsNullOrEmpty(address))
                throw new ValidationException("Invalid Exhibitor Address");
        }

        public static ExhibitorAddress Create(string address, int zipcode, string phoneNo, string officeNo, string exhibitorName, string emailId)
        {
            return new ExhibitorAddress(address, zipcode, phoneNo, officeNo, exhibitorName, emailId);
        }

        public void Update(string address, int zipcode, string phoneNo, string officeNo, string exhibitorName, string emailId)
        {
            Validate(address, zipcode, phoneNo, officeNo, exhibitorName, emailId);
            this.Address = address;
            this.ZipCode = zipcode;
            this.PhoneNo = phoneNo;
            this.OfficeNo = officeNo;
            this.ExhibitorName = exhibitorName;
            this.EmailId = emailId;
        }
    }
}