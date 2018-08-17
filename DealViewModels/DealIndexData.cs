using System.Collections.Generic;

using Phoenix.Models;

namespace Phoenix.Models.DealViewModels
{
    /// <summary> Represents the view model to use on all pages which should show Deals with their Units. </summary>
    public class DealIndexData
    {
        /// <summary> Gets or sets a deal. </summary>
        public IEnumerable<Deal> Deal {get; set; }

        /// <summary> Gets or sets a dealUnit. </summary>
        public IEnumerable<DealUnit> DealUnit {get; set; }

        /// <summary> Gets or sets a unit. </summary>
        public IEnumerable<Unit> Unit {get; set; }
    }
}