using Architecture.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Architecture.Database.Entities.Shared
{
    public class ProductCategory
    {
        // Issue:
        // The entity type 'ProductCategory' requires a primary key to be defined.
        // Happens while using ProductId and CategoryId as a compound PK.
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
