using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances.Kernel.Modules.Entities
{
    public abstract class Entity
    {
        [Key]
        [Column(Order = 1)]
        public Guid Id { get; set; }
    }
}
