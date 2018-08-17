using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Phoenix.Models
{
    public class Appraisal
    {
        /// <summary> Gets or sets the Appraisal's unique identifier. </summary>
        [Key]
        public int _id;
        /// <summary> Gets or sets the <see cref="Appraisal"/> submission date. </summary>
        [Display(Name="Submission Date")]
        [Required(ErrorMessage="Submission Date is Required")]
        [DataType(DataType.Date, ErrorMessage="Invalid Date Format")]
        [Range(typeof(DateTime),"1970-01-01","2030-01-01",
            ErrorMessage="Value for {0} must be between {1} and {2}")]
        public DateTime SubmissionDate { get; set; }
        /// <summary> Gets or sets the <see cref="Appraisal"/> branch. </summary>
        [Required]
        public string Branch { get; set; }
        /// <summary> Gets or sets the <see cref="Appraisal"/> user-input branch. </summary>
        [MaxLength(32, ErrorMessage="Branch name must be less than 32 characters")]
        public string BranchOther { get; set; }
        /*public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string AppraiserName { get; set; }
        public int TitleYear { get; set; }
        public string UnitMake { get; set; }
        public IEnumerable<SelectListItem> UnitMakeOptions { get; set; }
        public string UnitMakeOther { get; set; }
        public string UnitModel { get; set; }
        public string VIN { get; set; }
        public string HasSleeper { get; set; }
        public IEnumerable<SelectListItem> HasSleeperOptions { get; set; }
        public string HasSleeperOther { get; set; }
        public string SleeperConfig { get; set; }
        public IEnumerable<SelectListItem> SleeperConfigOptions { get; set; }
        public string SleeperConfigOther { get; set; }
        public int SleeperSize { get; set; }
        public string BunkBed { get; set; }
        public IEnumerable<SelectListItem> BunkBedOptions { get; set; }
        public string BunkBedOther { get; set; }
        public string TrimLevel { get; set; }
        public IEnumerable<SelectListItem> TrimLevelOptions { get; set; }
        public string TrimLevelOther { get; set; }
        public string EngineMake { get; set; }
        public IEnumerable<SelectListItem> EngineMakeOptions { get; set; }
        public string EngineMakeOther { get; set; }
        public int Horsepower { get; set; }
        public int EngineLiters { get; set; }
        public string Transmission { get; set; }
        public IEnumerable<SelectListItem> TransmissionOptions { get; set; }
        public string TransmissionOther { get; set; }
        public int Miles { get; set; }
        public int Hours { get; set; }
        public string ExhaustType { get; set; }
        public IEnumerable<SelectListItem> ExhaustTypeOptions { get; set; }
        public string ExhaustTypeOther { get; set; }
        public string ExhaustLocation { get; set; }
        public IEnumerable<SelectListItem> ExhaustLocationOptions { get; set; }
        public string ExhaustLocationOther { get; set; }
        public string Fairing { get; set; }
        public IEnumerable<SelectListItem> FairingOptions { get; set; }
        public string FairingOther { get; set; }
        public int HoodLength { get; set; }
        public int Wheelbase { get; set; }
        public string WheelsSteer { get; set; }
        public IEnumerable<SelectListItem> WheelsSteerOptions { get; set; }
        public string WheelsSteerOther { get; set; }
        public string WheelsDrive { get; set; }
        public IEnumerable<SelectListItem> WheelsDriveOptions { get; set; }
        public string WheelsDriveOther { get; set; }
        public string TiresSteerDepth { get; set; }
        public IEnumerable<SelectListItem> TiresSteerDepthOptions { get; set; }
        public string TiresSteerDepthOther { get; set; }
        public bool TiresDriveAreVirginRubber { get; set; }
        public bool TiresDriveAreDuals { get; set; }
        public string TiresDriveDepth { get; set; }
        public IEnumerable<SelectListItem> TiresDriveDepthOptions { get; set; }
        public string TiresDriveDepthOther { get; set; }
        public string BrakesFrontWear { get; set; }
        public IEnumerable<SelectListItem> BrakesFrontWearOptions { get; set; }
        public string BrakesRearWear { get; set; }
        public IEnumerable<SelectListItem> BrakesRearWearOptions { get; set; }
        public string AxleConfig { get; set; }
        public IEnumerable<SelectListItem> AxleConfigOptions { get; set; }
        public string AxleConfigOther { get; set; }
        public string AxleFrontWeight { get; set; }
        public IEnumerable<SelectListItem> AxleFrontWeightOptions { get; set; }
        public string AxleFrontWeightOther { get; set; }
        public string AxleRearWeight { get; set; }
        public IEnumerable<SelectListItem> AxleRearWeightOptions { get; set; }
        public string AxleRearWeightOther { get; set; }
        public string SuspensionType { get; set; }
        public IEnumerable<SelectListItem> SuspensionTypeOptions { get; set; }
        public string SuspensionTypeOther { get; set; }
        public string RearEndRatio { get; set; }
        public string FifthWheel { get; set; }
        public IEnumerable<SelectListItem> FifthWheelOptions { get; set; }
        public string FifthWheelOther { get; set; }
        public string Lockers { get; set; }
        public IEnumerable<SelectListItem> LockersOptions { get; set; }
        public string LockersOther { get; set; }
        public string DoubleFrame { get; set; }
        public IEnumerable<SelectListItem> DoubleFrameOptions { get; set; }
        public string DoubleFrameOther { get; set; }
        public string AfterTreatmentSystem { get; set; }
        public IEnumerable<SelectListItem> AfterTreatmentSystemOptions { get; set; }
        public string AfterTreatmentSystemOther { get; set; }
        public string OverallCondition { get; set; }


        /// <summary> Gets or sets the Deal foreign key reference. </summary>
        public int DealId { get; set; }

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
        */
    }
}