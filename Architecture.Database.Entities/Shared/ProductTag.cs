using Architecture.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Architecture.Database.Entities.Shared
{
    public class ProductTag
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int TagId { get; set; }

        public Tag Tag { get; set; }
    }
}
