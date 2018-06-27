using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Phoenix.Models
{
    public abstract class AuditedTable
    {
        public int AddUserID { get; set; }
        public DateTime AddDate { get; set; }
        public decimal AddDateTimeZone { get; set; }
        public int UpdateUserID { get; set; }
        public DateTime UpdateDate { get; set; }
        public decimal LastUpdateTimeZone { get; set; }
    }
}