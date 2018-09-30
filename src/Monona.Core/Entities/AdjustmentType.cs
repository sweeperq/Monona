using System.ComponentModel.DataAnnotations;

namespace Monona.Core.Entities
{
    public class AdjustmentType : IEntity<int>
    {
        [Key]
        public int Id { get; protected set; }

        [Required, StringLength(256)]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Enabled { get; set; } = true;
    }
}
