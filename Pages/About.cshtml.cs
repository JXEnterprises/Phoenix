using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Phoenix.Pages
{
    /// <summary> Represents the About Page. </summary>
    public class AboutModel : PageModel
    {
        /// <summary> Gets a link to the 'About JX' page on the corporate site </summary>    
        public string Link => "http://jxe.com/about/";

        /// <summary> Fires when the page is accessed via the GET HTTP verb. </summary>
        public void OnGet()
        {
            
        }
    }
}
