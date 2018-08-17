using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Phoenix.Models;

namespace Phoenix.Pages.Units
{
    public class DebugModel : PageModel
    {
        private readonly DealContext _context;

        public DebugModel(DealContext context)
        {
            _context = context;
        }

        public IList<Unit> Units { get; set; }

        public void OnGet()
        {
            
        }
    }
}