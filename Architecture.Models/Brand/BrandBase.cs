using Architecture.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Models.Brand
{
    public class BrandBase : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
