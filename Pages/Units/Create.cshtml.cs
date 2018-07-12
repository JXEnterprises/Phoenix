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
        private readonly Phoenix.Models.DealContext _context;

        /// <summary> The constructor. </summary>
        /// <param name="context"> The DealContext. See <see cref="DealContext"/>. </param>
        public CreateModel(Phoenix.Models.DealContext context)
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
    }
}