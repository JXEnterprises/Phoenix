using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Phoenix.Pages
{
    /// <summary> Represents an Error page. </summary>
    public class ErrorModel : PageModel
    {
        /// <summary> Gets or sets the error's HTTP response status code. </summary>
        public string RequestId { get; set; }

        /// <summary> Gets or sets a value indicating whether the HTTP response status code should be shown. </summary>
        /// <returns></returns>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        /// <summary> Fires when the page is accessed via the GET HTTP verb. </summary>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}
