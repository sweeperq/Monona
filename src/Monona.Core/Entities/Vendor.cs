using System.ComponentModel.DataAnnotations;

namespace Monona.Core.Entities
{
    public class Vendor : IEntity<int>
    {
        [Key]
        public int Id { get; protected set; }

        [Required, StringLength(256)]
        public string Name { get; set; }

        public string Address { get; set; }

        public string PoEmailAddresses { get; set; }

        public string PaymentTerms { get; set; }

        [StringLength(64)]
        public string StripFromSkuForClient { get; set; }

        public int? DefaultLeadDays { get; set; }

        public int? DefaultCountryOfOriginId { get; set; }

        public virtual Country DefaultCountryOfOrigin { get; set; }

        public int? DefaultGoogleCategoryId { get; set; }

        public virtual GoogleCategory DefaultGoogleCategory { get; set; }

        [StringLength(256)]
        public string DefaultBrand { get; set; }

        public string Notes { get; set; }

        public bool Enabled { get; set; } = true;
    }
}
