using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Monona.Core.Entities
{
    public class ReportGroup : IEntity<int>
    {
        [Key]
        public int Id { get; protected set; }

        [Required, StringLength(256)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
