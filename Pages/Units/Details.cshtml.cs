using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Phoenix.Models;

namespace Phoenix.Pages.Units
{
    /// <summary> Represents the "Unit Details" page model. </summary>
    public class DetailsModel : PageModel
    {
        private readonly Phoenix.Models.DealContext _context;

        /// <summary> The constructor. </summary>
        /// <param name="context"> The DealContext. See <see cref="DealContext"/>. </param>
        public DetailsModel(Phoenix.Models.DealContext context)
        {
            _context = context;
        }

        /// <summary> Gets or sets the Unit to be created. </summary>
        public Unit Unit { get; set; }

        /// <summary> Fires asynchronously when the page is accessed via the GET HTTP verb. </summary>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Unit = await _context.Unit.FirstOrDefaultAsync(m => m.ID == id);

            if (Unit == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
