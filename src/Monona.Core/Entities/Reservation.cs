using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Monona.Core.Entities
{
    public class Reservation : IEntity<int>
    {
        [Key]
        public int Id { get; protected set; }

        public int StoreId { get; set; }

        public virtual Store Store { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Range(0, int.MaxValue)]
        public int OrderId { get; set; }

        [Range(0, int.MaxValue)]
        public int ShipmentId { get; set; }

        [Range(0, int.MaxValue)]
        public int OrderItemId { get; set; }

        [Required, StringLength(64)]
        public string OrderNumber { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        public DateTimeOffset ReservedOn { get; set; } = DateTimeOffset.Now;
    }
}
