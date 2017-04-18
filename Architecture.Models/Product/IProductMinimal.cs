using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Models.Product
{
    public interface IProductMinimal : IProductBase
    {
        string Brand { get; set; }
    }
}
