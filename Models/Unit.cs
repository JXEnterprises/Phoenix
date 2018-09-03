using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Phoenix.Models
{
    /// <summary> Represents a truck, referred to as a Unit within Fusion. </summary>
    /// TODO: Handle picture links. Should they be some kind of Attachment object?
    public class Unit
    {
        /// <summary> Gets or sets the unique identifier. </summary>
        public int UnitId { get; set; }

        /// <summary> Gets or sets the title or model year. </summary>
        public int ModelYear { get; set; }
        
        //Make - lookup
        public string Make {get;set;}

        public string Model {get;set;}

        //Model - lookup
        /// <summary> Gets or sets the Vehicle Identification Number. </summary>
        public string VIN { get; set; }


        #region Standard Audit Fields
        /// <summary> Gets or sets the user who added the record. </summary>
        public int AddUserID { get; set; }

        // TODO: get rid of these annotations in favor of the Fluent API (see Asana task "EF - Standard Audit Fields")
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


}