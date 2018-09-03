using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Phoenix.Models
{
    #pragma warning disable CS0169
    /// <summary> Represents an appraisal of, and possible offer to purchase, 1 or more Units. </summary>
    public class Deal
    {
        public Deal()
        {
            Appraisals = new List<Appraisal>();
        }

        /// <summary> Gets or sets the Deal's unique identifier. </summary>
        [Key]
        public int _id;

        public DateTime? DateOfSubmission {get; set;}

        /// <summary> Gets or sets the control branch. </summary>
        /// <example> Madison </example>
        public string ControlBranch { get; set; }

        public string CustomerName {get;set;}

        public ICollection<Appraisal> Appraisals {get;set;}

        #region Standard Audit Fields
        /// <summary> Gets or sets the user who added the record. </summary>
        [Display(Name="User")]
        public int AddUserID { get; set; }

        /// <summary> Gets or sets the UTC date the record was added. </summary>
        [Display(Name="Date")]
        public DateTime AddDate { get; set; }

        /// <summary> Gets or sets the time zone offset of the date the record was added. </summary>
        [Display(Name="Time Zone")]
        public decimal AddDateTimeZone { get; set; }

        /// <summary> Gets or sets the user who last updated the record. </summary>
        [Display(Name="User")]
        public int UpdateUserID { get; set; }

        /// <summary> Gets or sets the UTC date the record was last updated. </summary>
        [Display(Name="Date")]
        public DateTime UpdateDate { get; set; }

        /// <summary> Gets or sets the time zone offset of the date the record was last updated. </summary>
        [Display(Name="Time Zone")]
        public decimal LastUpdateTimeZone { get; set; }
        #endregion

        /// <summary>
        /// Updates Audit fields for the record.
        /// </summary>
        /// <param name="userId"> The user. </param>
        public void UpdateAuditFields(int userId)
        {
            //! WARNING: Possible cross-platform idiosyncrasies!
            var timeZone = TimeZoneInfo.Local;
            var offset = timeZone.GetUtcOffset(DateTime.Now);
            decimal offsetHours = offset.Hours + (offset.Minutes/60);
            if (AddUserID == 0)
            {
                AddUserID = userId;
                AddDate = DateTime.UtcNow;
                AddDateTimeZone = offsetHours;
            }
            UpdateUserID = userId;
            UpdateDate = DateTime.UtcNow;
            LastUpdateTimeZone = offsetHours;
        }
    }
    #pragma warning restore CS0169
}