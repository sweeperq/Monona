using System.ComponentModel.DataAnnotations;

namespace Monona.Core.Entities
{
    public class Store : IEntity<int>
    {
        [Key]
        public int Id { get; protected set; }

        [Required, StringLength(256)]
        public string Name { get; set; }

        [StringLength(16)]
        public string Abbreviation { get; set; }

        [StringLength(256), Url]
        public string Url { get; set; }

        public bool Enabled { get; set; } = true;
    }
}
