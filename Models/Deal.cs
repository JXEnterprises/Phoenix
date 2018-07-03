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
        /// <summary> Gets or sets the Deal's unique identifier. </summary>
        [Key]
        private int _id;

        /// <summary> Gets the number of Units in the Deal. </summary>
        public int UnitCount => (Units != null ? Units.Count : 0);

        // ? control branch? 

        /// <summary> A navigation property representing the Units in this Deal </summary>
        public ICollection<Unit> Units {get; set; }

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
    }
    #pragma warning restore CS0169
}