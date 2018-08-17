

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Phoenix
{
    public static class RazorHelper
    {
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
    }
}