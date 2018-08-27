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

        /// <summary> Gets or sets the current owner's name. </summary>
        [Display(Name="Owner")]
        public string CustomerName { get; set; }

        /// <summary> Gets or sets the current owner's address. </summary>
        public string CustomerAddress { get; set; }

        /// <summary> Gets or sets the appraiser's name. </summary>
        public string AppraiserName { get; set; }

        //Branch - lookup

        /// <summary> Gets or sets the title or model year. </summary>
        public int ModelYear { get; set; }
        
        //Make - lookup

        //Model - lookup
        /// <summary> Gets or sets the Vehicle Identification Number. </summary>
        public string VIN { get; set; }

        //Engine Make - string

        //Horsepower

        //Engine Liters

        /// <summary> Gets or sets the collection navigation property for mapping to Units. </summary>
        public IList<DealUnit> DealUnits { get; set; }

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

    public class UnitCharacteristic 
    {
        public UnitCharacteristic() 
        {
            ListValues = new List<UnitCharacteristicListValue>();
        }

        public int UnitCharacteristicId {get;set;}

        public string UnitCharacteristicName {get;set;}

        public string UnitCharacteristicType {get;set;}

        public List<UnitCharacteristicListValue> ListValues {get;set;}
    }

    public class UnitCharacteristicListValue 
    {
        public int ListValueId {get;set;}
        public string ListValueName {get;set;}
    }

    public class UnitCharacteristicValue
    {
        public int UnitCharacteristicValueId {get;set;}
        public int UnitId {get;set;}
        public int UnitCharacteristicId {get;set;}
        public int IntValue {get;set;}
        public string StringValue {get;set;}
    }
}