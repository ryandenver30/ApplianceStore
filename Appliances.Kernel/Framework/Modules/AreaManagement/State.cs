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
    [Table("State")]
    public class State : MasterEntity
    {
        public string StateName { get; set; }
        public string StateCode { get; set; }
        [Column("CountryId")]
        public virtual Country Country { get; set; }

        public State()
        {
            
        }
        private static void Validate(string name)
        {
            if (String.IsNullOrEmpty(name))
                throw new ValidationException("Invalid Category Name");
        }
        public State(string name,string code)
        {
            Validate(name);
            this.StateName = name;
            this.StateCode = code;
        }
        public static State Create(string name, string code)
        {
            return new State(name, code);
        }
        public void Update(string name,string code)
        {
            Validate(name);
            this.StateName = name;
            this.StateCode = code;
        }

    }
}
