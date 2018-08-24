

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Phoenix
{
    /// <summary> Represents extension methods for use within the site. </summary>
    public static class RazorHelper
    {
        /// <summary> Presents a debug table of a collection of type <c>TItem</c> within a Razor Page. </summary>
        /// <param name="items"> The collection to display. </param>
        /// <returns> Returns a <see cref="HelperResult"/>, used by Razor Pages to easily insert HTML. </returns>
        public static HelperResult DebugTable<TItem>(this IEnumerable<TItem> items)
        {
            var helperResult = new HelperResult(async writer =>
            {
                var firstItem = items.FirstOrDefault();
                writer.Write("<table>");
                writer.Write("<tr>");
                if (firstItem == null)
                    return;
                var props = firstItem.GetType().GetProperties();
                foreach (var prop in props)
                    writer.Write("<td>" + prop.Name + "</td>");
                writer.Write("</tr>");
                foreach (var item in items)
                {
                    writer.Write("<tr>");
                    foreach (var prop in props)
                    {
                        writer.Write("<td>" + prop.GetValue(item) + "</td>");
                    }
                    writer.Write("</tr>");
                }
                writer.Write("</table>");
            });

            return helperResult;
        }

        /// <summary> Indicates whether a string property backed by a select tag is set to the value "other" (case insensitive). </summary>
        /// <param name="property"> The property to check for the value. </param>
        /// <param name="backingList"> The list of select options backing the property. </param>
        /// <returns> Returns true if the string is the word "other", false otherwise. </returns>
        public static bool hasOtherSelected<String>(this String property, List<SelectListItem> backingList) => 
            backingList.Any(b => b.Value.ToLowerInvariant() == property.ToString());
            
    }
}