using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using Phoenix.Models;
using Phoenix.Models.DealViewModels;

namespace Phoenix.Pages.Appraisal
{
    /// <summary> Represents the main Appraisal submission page. </summary>
    public class EditModel : PageModel
    {
        /// <summary> Gets or sets the data view model for the Appraisal page </summary>
        [BindProperty]
        public Phoenix.Models.Appraisal EditAppraisal { get; set; }

        private readonly DealContext _context;

        /// <summary> The constructor. </summary>
        /// <param name="context"> The data session backing Phoenix. </param>
        public EditModel(DealContext context)
        {
            _context = context;
        }

        /// <summary> Fires asynchronously when the page is accessed via the GET HTTP verb. </summary>
        public async Task<IActionResult> OnGetAsync(int? appraisalId)
        {
            EditAppraisal = _context.Appraisal
            .Include(x => x.Deal)
            .Include(x => x.Unit)
            .FirstOrDefault(x => x.Id == appraisalId);

            var listValues = _context.AppraisalCharacteristicValue.Where(x => x.Appraisal.Id == appraisalId);
            foreach(var c in this.AppraisalCharacteristics)
            {
                var mval = listValues.FirstOrDefault(x => x.CharacteristicName == c.AppraisalCharacteristicName);
                if (mval != null)
                {
                    c.SelectedValue = mval.StringValue;
                }
            }

            return Page();
        }

        /// <summary> Fires asynchronously when the page is submitted via the SAVE button. </summary>
        public async Task<IActionResult> OnPostAsync(Phoenix.Models.Appraisal editAppraisal)
        {
            //basic testing of the absolute necessities. This doesn't apply to most fields!
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var appraisal = _context.Appraisal
            .Include(x => x.Unit)  
            .Include(x => x.Values)
            .FirstOrDefault(x => x.Id == editAppraisal.Id);
            appraisal.Unit.Make = editAppraisal.Unit.Make;
            appraisal.Unit.Model = editAppraisal.Unit.Model;
            appraisal.Unit.ModelYear = editAppraisal.Unit.ModelYear;

            appraisal.AppraisedBy = editAppraisal.AppraisedBy;

            foreach(var c in AppraisalCharacteristics)
            {
                var val = Request.Form[c.AppraisalCharacteristicName];
                var aVal = appraisal.Values.FirstOrDefault(x => x.CharacteristicName == c.AppraisalCharacteristicName);
                if (aVal != null )
                {
                    aVal.StringValue = val;
                }
            }

            _context.Update(appraisal);
            
            await _context.SaveChangesAsync();

            foreach(var c in this.AppraisalCharacteristics)
            {
                var mval = appraisal.Values.FirstOrDefault(x => x.CharacteristicName == c.AppraisalCharacteristicName);
                if (mval != null)
                {
                    c.SelectedValue = mval.StringValue;
                }
            }
            EditAppraisal = appraisal;
    
            return Page();
        }

        /// <summary> Fires asynchronously when the page is submitted via the FINISH button. </summary>
        public async Task<IActionResult> OnPostAsyncFinish()
        {
            //basic testing of the absolute necessities. This doesn't apply to most fields!
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _context.SaveChangesAsync();

            //return to main index???
            return RedirectToPage("../Index");
        }

        private List<AppraisalCharacteristic> _lst = new List<AppraisalCharacteristic>() {
                    new AppraisalCharacteristic { AppraisalCharacteristicName = "Sleeper", AppraisalCharacteristicType = "YesNo"},
                    new AppraisalCharacteristic { AppraisalCharacteristicName = "Sleeper Configuration", AppraisalCharacteristicType = "List", 
                    ListValues = new List<AppraisalCharacteristicListValue>() {
                        new AppraisalCharacteristicListValue() {ListValueId = 1, ListValueName = "High Roof"},
                        new AppraisalCharacteristicListValue() {ListValueId = 2, ListValueName = "Mid Roof"},
                        new AppraisalCharacteristicListValue() {ListValueId = 3, ListValueName = "Flat Top"},
                        new AppraisalCharacteristicListValue() {ListValueId = 4, ListValueName = "Not Applicable - Day Cab, Straight Truck, etc"},
                    }},
                    new AppraisalCharacteristic { AppraisalCharacteristicName = "Sleeper Size", AppraisalCharacteristicType = "List",
                    ListValues = new List<AppraisalCharacteristicListValue>() {
                        new AppraisalCharacteristicListValue() {ListValueId = 5, ListValueName = "78-80+"},
                        new AppraisalCharacteristicListValue() {ListValueId = 6, ListValueName = "72-77"},
                        new AppraisalCharacteristicListValue() {ListValueId = 7, ListValueName = "66-71"},
                        new AppraisalCharacteristicListValue() {ListValueId = 8, ListValueName = "59-65"},
                        new AppraisalCharacteristicListValue() {ListValueId = 9, ListValueName = "36-58"},
                        new AppraisalCharacteristicListValue() {ListValueId = 4, ListValueName = "Not Applicable - Day Cab, Straight Truck, etc"},
                    }},
                    new AppraisalCharacteristic { AppraisalCharacteristicName = "Bunk Bed", AppraisalCharacteristicType = "YesNo"},
                    new AppraisalCharacteristic { AppraisalCharacteristicName = "Interior Options"},
                    new AppraisalCharacteristic { AppraisalCharacteristicName = "Engine Make"},
                    new AppraisalCharacteristic { AppraisalCharacteristicName = "Horse Power"},
                    new AppraisalCharacteristic { AppraisalCharacteristicName = "Engine Liters"},
                    new AppraisalCharacteristic { AppraisalCharacteristicName = "Transmission"},
                };
        public List<AppraisalCharacteristic> AppraisalCharacteristics { 
            get { return _lst; } 
            set { _lst = value;}
        }
    }
}