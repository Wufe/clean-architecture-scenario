using Architecture.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Database.Entities
{
    public class ProductTag : IEntity
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int TagId { get; set; }

        public Tag Tag { get; set; }
    }
}
