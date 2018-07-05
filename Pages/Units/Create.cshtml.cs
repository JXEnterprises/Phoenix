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

            _context.Unit.Add(Unit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}