using Architecture.Models.Interfaces;
using Architecture.Models.Product;
using Architecture.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Models.Rating
{
    public interface IRatingBase
    {
        int Vote { get; set; }

        string Comment { get; set; }

        ProductBase Product { get; set; }

        UserBase User { get; set; }
    }
}
