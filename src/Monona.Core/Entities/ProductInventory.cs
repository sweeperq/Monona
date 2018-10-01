using System;
using System.ComponentModel.DataAnnotations;

namespace Monona.Core.Entities
{
    public class ProductInventory
    {
        [Key]
        public int ProductId { get; set; }

        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }

        [Range(0, int.MaxValue)]
        public int ReservedQuantity { get; set; }

        public int AvailableQuantity { get; set; }

        [Range(0, int.MaxValue)]
        public int PoQuantity { get; set; }

        public int PotentialQuantity { get; set; }

        public DateTimeOffset? NextPoOn { get; set; }
    }
}
