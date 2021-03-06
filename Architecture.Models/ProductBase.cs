﻿namespace Architecture.Models
{
    public class ProductBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int Views { get; set; }

        public BrandBase Brand { get; set; }
    }
}
