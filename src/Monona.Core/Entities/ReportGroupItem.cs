using System.ComponentModel.DataAnnotations;

namespace Monona.Core.Entities
{
    public class ReportGroupItem : IEntity<int>
    {
        [Key]
        public int Id { get; protected set; }

        public int ReportGroupId { get; set; }

        public virtual ReportGroup ReportGroup { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
