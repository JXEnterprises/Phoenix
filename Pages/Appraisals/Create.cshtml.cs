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
    public class CreateModel : PageModel
    {
        /// <summary> Gets or sets the data view model for the Appraisal page </summary>
        [BindProperty]
        public CreateAppraisal CreateAppraisal { get; set; }

        private readonly DealContext _context;

        /// <summary> The constructor. </summary>
        /// <param name="context"> The data session backing Phoenix. </param>
        public CreateModel(DealContext context)
        {
            _context = context;
        }

        /// <summary> Fires asynchronously when the page is accessed via the GET HTTP verb. </summary>
        public async Task<IActionResult> OnGetAsync(int? dealId)
        {
            CreateAppraisal = new CreateAppraisal() {DealId = dealId.Value};

            return Page();
        }

        /// <summary> Fires asynchronously when the page is submitted via the SAVE button. </summary>
        public async Task<IActionResult> OnPostAsync(CreateAppraisal createAppraisal)
        {
            //basic testing of the absolute necessities. This doesn't apply to most fields!
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var deal = _context.Deal.FirstOrDefault(x => x.Id == createAppraisal.DealId);
            var unit = new Unit();
            unit.Make = createAppraisal.Unit.Make;
            unit.Model = createAppraisal.Unit.Model;
            unit.ModelYear = createAppraisal.Unit.ModelYear;

            var appraisal = new Phoenix.Models.Appraisal();
            appraisal.Deal = deal;
            appraisal.Unit = unit;
            appraisal.AppraisedBy = createAppraisal.AppraisedBy;

            _context.Appraisal.Add(appraisal);

            var listValues = new List<AppraisalCharacteristicValue>();
            foreach(var c in AppraisalCharacteristics)
            {
                var val = Request.Form[c.AppraisalCharacteristicName];
                listValues.Add(new AppraisalCharacteristicValue() {
                    Appraisal = appraisal,
                    CharacteristicName = c.AppraisalCharacteristicName,
                    StringValue = val
                });
            }

            appraisal.Values = listValues;

            await _context.SaveChangesAsync();

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
        public List<AppraisalCharacteristic> AppraisalCharacteristics { get {
            return new List<AppraisalCharacteristic>() {
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
            }
        }


    }
}