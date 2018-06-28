using System;
using System.Collections.Generic;

namespace Phoenix.Models
{
    /// <summary> Represents an appraisal of, and possible offer to purchase, 1 or more Units. </summary>
    public class Deal
    {
        /// <summary> Gets or sets the Deal's unique identifier. </summary>
        public int ID { get; set; }

        /// <summary> Gets the number of Units in the Deal. </summary>
        public int UnitCount => (Units != null ? Units.Count : 0);

        // control branch? 

        /// <summary> A navigation property representing the Units in this Deal </summary>
        public ICollection<Unit> Units {get; set; }

        #region Standard Audit Fields
        /// <summary> Gets or sets the user who added the record. </summary>
        public int AddUserID { get; set; }

        /// <summary> Gets or sets the UTC date the record was added. </summary>
        public DateTime AddDate { get; set; }

        /// <summary> Gets or sets the time zone offset of the date the record was added. </summary>
        public decimal AddDateTimeZone { get; set; }

        /// <summary> Gets or sets the user who last updated the record. </summary>
        public int UpdateUserID { get; set; }

        /// <summary> Gets or sets the UTC date the record was last updated. </summary>
        public DateTime UpdateDate { get; set; }

        /// <summary> Gets or sets the time zone offset of the date the record was last updated. </summary>
        public decimal LastUpdateTimeZone { get; set; }
        #endregion
    }
}