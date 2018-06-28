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
    public class DetailsModel : PageModel
    {
        private readonly Phoenix.Models.DealContext _context;

        public DetailsModel(Phoenix.Models.DealContext context)
        {
            _context = context;
        }

        public Unit Unit { get; set; }

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
