using System;

namespace Phoenix
{
    /// <summary>
    /// Represents a truck, referred to as a Unit within Fusion.
    /// </summary>
    public class Unit
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Gets or sets the current owner's name.
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        ///  Gets or sets the current owner's address.
        /// </summary>
        public string CustomerAddress { get; set; }
        /// <summary>
        /// Gets or sets the appraiser's name.
        /// </summary>
        public string AppraiserName { get; set; }

        //Branch - lookup

        /// <summary>
        /// Gets or sets the title or model year.
        /// </summary>
        public int ModelYear { get; set; }
        
        //Make - lookup

        //Model - lookup
        /// <summary>
        /// Gets or sets the Vehicle Identification Number.
        /// </summary>
        public string VIN { get; set; }

        //Engine Make - string

        //Horsepower

        //Engine Liters

        //...

        /// TODO: Handle picture links. Should they be some kind of Attachment object?
        
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