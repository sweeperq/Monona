using System.ComponentModel.DataAnnotations;

namespace Monona.Core.Entities
{
    public class Country : IEntity<int>
    {
        [Key]
        public int Id { get; protected set; }

        [Required, StringLength(256)]
        public string Name { get; set; }

        [Required, StringLength(2), RegularExpression(@"^[A-Z]{2}$", ErrorMessage = "{0} must be two upper-case letters")]
        public string Abbreviation { get; set; }

        public bool Enabled { get; set; } = true;
    }
}
