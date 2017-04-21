using Architecture.Database.Entities.Shared;
using Architecture.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Architecture.Database.Entities
{
    public class Product : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public Brand Brand { get; set; }

        public int BrandId { get; set; }

        public IEnumerable<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

        public IEnumerable<ProductTag> ProductTags { get; set; } = new List<ProductTag>();

        public IEnumerable<Rating> Ratings { get; set; } = new List<Rating>();

        public IEnumerable<ProductUser> ProductUsers { get; set; } = new List<ProductUser>();


    }
}
