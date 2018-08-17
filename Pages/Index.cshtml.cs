using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using Phoenix.Models;
using Phoenix.Models.DealViewModels;

namespace Phoenix.Pages
{
    /// <summary> Represents the root Index page </summary>
    public class IndexModel : PageModel
    {
        /// <summary> Fires asynchronously when the page is accessed via the GET HTTP verb. </summary>
        public async Task OnGetAsync()
        {
            //TODO: add filter for current user, with checkbox
            //first, get all units, ordered by unit-level attributes
            //Deal = await _context.Deal
                //TODO: set up app for .TakeWhile(deal => deal.ControlBranch == User.Branch)
                // .OrderByDescending(deal => deal.UpdateDate)
                // .AsNoTracking()
                // .ToListAsync();
            DealData = new DealIndexData();
            DealData.Unit = await _context.Unit
                .OrderBy(u => u.UpdateDate)
                .ToListAsync();

            //next, get all dealUnits for those Units, that are still coupled
            //var dealUnits = await _context.

            //then, get all units, ordered by unit-level attr.


            //SIMPLE WAY: Unit = await _context.Unit.ToListAsync();
        }

        /// <summary> The Recent Deals list contents </summary>
        public DealIndexData DealData {get; set; }

        /// <summary> The Recent Deals list contents </summary>
        private readonly DealContext _context;

        /// <summary> The constructor. </summary>
        /// <param name="context"></param>
        public IndexModel(DealContext context)
        {
            _context = context;
        }
    }
}
