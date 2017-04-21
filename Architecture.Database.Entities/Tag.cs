using Architecture.Database.Entities.Shared;
using Architecture.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Architecture.Database.Entities
{
    public class Tag : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<ProductTag> ProductTags { get; set; } = new List<ProductTag>();
    }
}
