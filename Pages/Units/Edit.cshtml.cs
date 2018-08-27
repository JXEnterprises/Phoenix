using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Phoenix.Models;

namespace Phoenix.Pages.Units
{
    /// <summary> Represents the "Edit Unit" page model. </summary>
    public class EditModel : PageModel
    {
        private readonly Phoenix.Models.DealContext _context;

        /// <summary> The constructor. </summary>
        /// <param name="context"> The DealContext. See <see cref="DealContext"/>. </param>
        public EditModel(Phoenix.Models.DealContext context)
        {
            _context = context;
        }

        /// <summary> Gets or sets the Unit to be edited. </summary>
        [BindProperty]
        public Unit Unit { get; set; }

        /// <summary> Fires asynchronously when the page is accessed via the GET HTTP verb. </summary>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Unit = await _context.Unit.FirstOrDefaultAsync(m => m.UnitId == id);

            if (Unit == null)
            {
                return NotFound();
            }
            return Page();
        }
        

        /// <summary> Fires asynchronously when the page is accessed via the POST HTTP verb. </summary>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Unit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.UnitExists(Unit.UnitId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
