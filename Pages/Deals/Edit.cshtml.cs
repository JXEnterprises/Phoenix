using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Phoenix.Models;

namespace Phoenix.Pages.Deals
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
        public Deal Deal{ get; set; }

        /// <summary> Fires asynchronously when the page is accessed via the GET HTTP verb. </summary>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Deal = await _context.Deal
            .Include(x => x.Appraisals)
            .ThenInclude(x => x.Unit)
            .FirstOrDefaultAsync(m => m.Id == id);

            if (Deal == null)
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

            _context.Attach(Deal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.DealExists(Deal.Id))
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
