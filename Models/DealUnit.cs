namespace Phoenix.Models
{
    /// <summary> Represents a mapping between a Deal and a Unit. </summary>
    public class DealUnit
    {
        /// <summary> Gets or sets the Deal foreign key reference. </summary>
        public int DealId { get; set; }
        /// <summary> Gets or sets the Deal reference navigation property. </summary>
        public Deal Deal { get; set; }

        /// <summary> Gets or sets the Unit foreign key reference. </summary>
        public int UnitId { get; set; }
        /// <summary> Gets or sets the Unit reference navigation property. </summary>
        public Unit Unit { get; set; }

        /// <summary> Gets or sets a value indicating whether this relationship still exists. </summary>
        public bool IsUnlinked { get; set; }
    }
}