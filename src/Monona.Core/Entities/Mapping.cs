using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Monona.Core.Entities
{
    public class Mapping : IEntity<int>
    {
        [Key]
        public int Id { get; protected set; }

        public int StoreId { get; set; }

        public virtual Store Store { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Required, StringLength(64)]
        public string StoreSku { get; set; }

        [Range(1, int.MaxValue)]
        public int QuantityMultiplier { get; set; }
    }
}
