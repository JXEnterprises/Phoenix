using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Phoenix.Models.DealViewModels
{
    public class AppraisalData
    {
        public List<SelectListItem> BranchOptions { get; set; }
        
        /// <summary> Gets or sets the navigation property for the Appraisal. </summary>
        public Appraisal Appraisal {get; set; }

        /// <summary> Gets or sets the navigation property for the Deal. </summary>
        public Deal Deal { get; set; }

        public void PopulateListItems()
        {
            BranchOptions = new List<SelectListItem>
            {
                new SelectListItem {Text = "Bloomington", Value = "Bloomington"},
                new SelectListItem {Text = "Bolingbrook", Value = "Bolingbrook"},
                new SelectListItem {Text = "Elmhurst", Value = "Elmhurst"},
                new SelectListItem {Text = "Fort Wayne", Value = "Fort Wayne"},
                new SelectListItem {Text = "Grand Rapids", Value = "Grand Rapids"},
                new SelectListItem {Text = "Green Bay", Value = "Green Bay"},
                new SelectListItem {Text = "Indinanapolis", Value = "Indinanapolis"},
                new SelectListItem {Text = "Lansing", Value = "Lansing"},
                new SelectListItem {Text = "Madison", Value = "Madison"},
                new SelectListItem {Text = "Rockford", Value = "Rockford"},
                new SelectListItem {Text = "Wadsworth", Value = "Wadsworth"},
                new SelectListItem {Text = "Waukesha", Value = "Waukesha"},
                new SelectListItem {Text = "Wausau", Value = "Wausau"},
                new SelectListItem {Text = "OTHER", Value = "Other"}
            };
        }

        public AppraisalData()
        {
            PopulateListItems();
        }
    }
}