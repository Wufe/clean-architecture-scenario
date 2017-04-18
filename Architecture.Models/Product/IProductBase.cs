using Architecture.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Models.Product
{
    public interface IProductBase : IEntity
    {
        string Name { get; set; }

        string Description { get; set; }
    }
}
