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

namespace Phoenix.Pages.Units
{
    /// <summary> Represents the main Appraisal submission page. </summary>
    public class AppraisalModel : PageModel
    {
        /// <summary> Gets or sets the data view model for the Appraisal page </summary>
        [BindProperty]
        public AppraisalData AppraisalData { get; set; }

        private readonly DealContext _context;

        /// <summary> The constructor. </summary>
        /// <param name="context"> The data session backing Phoenix. </param>
        public AppraisalModel(DealContext context)
        {
            _context = context;
        }

        /// <summary> Fires asynchronously when the page is accessed via the GET HTTP verb. </summary>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (AppraisalData == null)
                AppraisalData = new AppraisalData();
            if (id.HasValue)
            {
                AppraisalData.Appraisal = await _context.Appraisal.FindAsync(id);
                if (AppraisalData.Appraisal == null)
                {
                    return NotFound();
                }
                //else you can grab the Deal as well, probably off the Appraisal
            }
            return Page();
        }

        /// <summary> Fires asynchronously when the page is submitted via the SAVE button. </summary>
        public async Task<IActionResult> OnPostAsyncSave()
        {
            //basic testing of the absolute necessities. This doesn't apply to most fields!
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AppraisalData).State = EntityState.Modified;

            try 
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.AppraisalExists(AppraisalData.Appraisal._id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //show save success message

            return Page();
        }

        /// <summary> Fires asynchronously when the page is submitted via the FINISH button. </summary>
        public async Task<IActionResult> OnPostAsyncFinish()
        {
            //basic testing of the absolute necessities. This doesn't apply to most fields!
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AppraisalData).State = EntityState.Modified;

            try 
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.AppraisalExists(AppraisalData.Appraisal._id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //TODO: Send the Appraisal record to a service or the context
            //      to attempt to finalize this Unit on this Deal

            //show save success message on the target page

            //return to main index???
            return RedirectToPage("../Index");
        }
    }
}