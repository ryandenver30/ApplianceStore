using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances.Kernel.Modules.Entities
{
    public class MasterEntity : Entity
    {
        public static TimeZoneInfo Ireland_Zone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
        public DateTime CreatedOn { get; private set; }
        public Guid? CreatedBy { get; set; }
        public DateTime LastModifiedOn { get; private set; }
        public Guid? LastModifiedBy { get; set; }
        public bool IsDeleted { get; private set; }

        public MasterEntity()
        {
            //CreatedOn = LastModifiedOn = DateTime.Now;
            CreatedOn = LastModifiedOn = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Ireland_Zone);
            this.Id = Guid.NewGuid();
            //TODO: Set CreatedBy and ModifiedBy

            //CreatedBy = "";
            //LastModifiedBy = "test_user";

            //TODO: Need to check ??
        }

        public void MarkAsDeleted()
        {
            IsDeleted = true;
            LastModifiedOn = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Ireland_Zone);
            //TODO: Dont forget to set the Modified By     
        }
    }
}
