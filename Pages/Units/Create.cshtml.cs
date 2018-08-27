using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Phoenix.Models;

namespace Phoenix.Pages.Units
{
    /// <summary> Represents the "Create Unit" page model. </summary>
    public class CreateModel : PageModel
    {
        private readonly DealContext _context;

        /// <summary> The constructor. </summary>
        /// <param name="context"> The DealContext. See <see cref="DealContext"/>. </param>
        public CreateModel(DealContext context)
        {
            _context = context;
        }

        /// <summary> Fires when the page is accessed via the GET HTTP verb. </summary>
        public IActionResult OnGet()
        {
            return Page();
        }

        /// <summary> Gets or sets the Unit to be created. </summary>
        [BindProperty]
        public Unit Unit { get; set; }

        /// <summary> Fires asynchronously when the page is accessed via the POST HTTP verb. </summary>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //TODO: Extract into a method (on DealContext?)
            Unit.UpdateAuditFields(userId: 1);
            _context.Unit.Add(Unit);
            var deal = new Deal();
            deal.UpdateAuditFields(userId: 1);
            var dealUnit = new DealUnit { Deal = deal, Unit = Unit};
            deal.DealUnits = new List<DealUnit>{dealUnit};
            //TODO: Add a switch or another Action that will handle adding to an existing Deal
            _context.Deal.Add(deal);
            _context.DealUnit.Add(dealUnit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    
        public List<UnitCharacteristic> UnitCharacteristics { get {
            return new List<UnitCharacteristic>() {
                    new UnitCharacteristic { UnitCharacteristicName = "Sleeper", UnitCharacteristicType = "YesNo"},
                    new UnitCharacteristic { UnitCharacteristicName = "Sleeper Configuration", UnitCharacteristicType = "List", 
                    ListValues = new List<UnitCharacteristicListValue>() {
                        new UnitCharacteristicListValue() {ListValueId = 1, ListValueName = "High Roof"},
                        new UnitCharacteristicListValue() {ListValueId = 2, ListValueName = "Mid Roof"},
                        new UnitCharacteristicListValue() {ListValueId = 3, ListValueName = "Flat Top"},
                        new UnitCharacteristicListValue() {ListValueId = 4, ListValueName = "Not Applicable - Day Cab, Straight Truck, etc"},
                    }},
                    new UnitCharacteristic { UnitCharacteristicName = "Sleeper Size", UnitCharacteristicType = "List",
                    ListValues = new List<UnitCharacteristicListValue>() {
                        new UnitCharacteristicListValue() {ListValueId = 5, ListValueName = "78-80+"},
                        new UnitCharacteristicListValue() {ListValueId = 6, ListValueName = "72-77"},
                        new UnitCharacteristicListValue() {ListValueId = 7, ListValueName = "66-71"},
                        new UnitCharacteristicListValue() {ListValueId = 8, ListValueName = "59-65"},
                        new UnitCharacteristicListValue() {ListValueId = 9, ListValueName = "36-58"},
                        new UnitCharacteristicListValue() {ListValueId = 4, ListValueName = "Not Applicable - Day Cab, Straight Truck, etc"},
                    }},
                    new UnitCharacteristic { UnitCharacteristicName = "Bunk Bed", UnitCharacteristicType = "YesNo"},
                    new UnitCharacteristic { UnitCharacteristicName = "Interior Options"},
                    new UnitCharacteristic { UnitCharacteristicName = "Engine Make"},
                    new UnitCharacteristic { UnitCharacteristicName = "Horse Power"},
                    new UnitCharacteristic { UnitCharacteristicName = "Engine Liters"},
                    new UnitCharacteristic { UnitCharacteristicName = "Transmission"},
                };
            }
        }
    }
}