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

namespace Phoenix.Pages.Deals
{
    /// <summary> Represents the "Create Unit" page model. </summary>
    public class CreateModel : PageModel
    {
        private readonly Phoenix.Models.DealContext _context;

        public CreateDeal CreateDeal{ get; set; }

        /// <summary> The constructor. </summary>
        /// <param name="context"> The DealContext. See <see cref="DealContext"/>. </param>
        public CreateModel(Phoenix.Models.DealContext context)
        {
            _context = context;
        }

        /// <summary> Gets or sets the Unit to be edited. </summary>
        [BindProperty]
        public Deal Deal{ get; set; }

        /// <summary> Fires asynchronously when the page is accessed via the GET HTTP verb. </summary>
        public async Task<IActionResult> OnGetAsync()
        {
            CreateDeal = new CreateDeal();
            return Page();
        }
        

        /// <summary> Fires asynchronously when the page is accessed via the POST HTTP verb. </summary>
        public async Task<IActionResult> OnPostAsync(CreateDeal createDeal)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Attach(Deal).State = EntityState.Modified;
            var newDeal = new Deal();
            newDeal.ControlBranch = createDeal.ControlBranch;
            newDeal.CustomerName = createDeal.CustomerName;
            newDeal.DateOfSubmission = createDeal.DateOfSubmission;

            _context.Deal.Add(newDeal);

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

            return RedirectToAction("Edit", new {id = newDeal.Id});
        }
    }
}
