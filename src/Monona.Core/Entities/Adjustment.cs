using System;
using System.ComponentModel.DataAnnotations;

namespace Monona.Core.Entities
{
    public class Adjustment : IEntity<int>
    {
        [Key]
        public int Id { get; protected set; }

        public int AdjustmentTypeId { get; set; }

        public virtual AdjustmentType AdjustmentType { get; set; }

        public int? StoreId { get; set; }

        public virtual Store Store { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        [StringLength(256)]
        public string ReferenceNumber { get; set; }

        public int Quantity { get; set; }

        public DateTimeOffset AdjustmentDate { get; set; } = DateTimeOffset.Now;
    }
}
