using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Phoenix.Pages
{
    public class AboutModel : PageModel
    {
        public string Link => "http://jxe.com/about/";

        public void OnGet()
        {
            
        }
    }
}
