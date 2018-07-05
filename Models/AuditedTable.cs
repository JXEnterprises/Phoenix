using System;

namespace Phoenix.Models
{
    /// <summary>
    /// A possibly junk class???
    /// </summary>
    public abstract class AuditedTable
    {
        /// <summary>
        /// A junk constructor
        /// </summary>
        public AuditedTable()
        {
            throw new NotImplementedException("Don't actually use this until we can figure out how to make it work like we want!");
        }


        #region Standard Audit Fields
        /// <summary>
        /// Gets or sets the user who added the record.
        /// </summary>
        public int AddUserID { get; set; }
        /// <summary>
        /// Gets or sets the UTC date the record was added.
        /// </summary>
        public DateTime AddDate { get; set; }
        /// <summary>
        /// Gets or sets the time zone offset of the date the record was added.
        /// </summary>
        public decimal AddDateTimeZone { get; set; }
        /// <summary>
        /// Gets or sets the user who last updated the record.
        /// </summary>
        public int UpdateUserID { get; set; }
        /// <summary>
        /// Gets or sets the UTC date the record was last updated.
        /// </summary>
        public DateTime UpdateDate { get; set; }
        /// <summary>
        /// Gets or sets the time zone offset of the date the record was last updated.
        /// </summary>
        public decimal LastUpdateTimeZone { get; set; }
        #endregion
    }
}