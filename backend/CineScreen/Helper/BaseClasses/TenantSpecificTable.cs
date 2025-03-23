using CineScreen.Data.Models.SharedTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineScreen.Helper.BaseClasses
{
    public abstract class TenantSpecificTable : BaseEntity
    {
        public int TenantId { get; set; }
        [ForeignKey(nameof(TenantId))]
        public Tenant? Tenant { get; set; }
    }

}
