using Architecture.Models.Product;
using Architecture.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Models.Rating
{
    public class RatingBase : IRatingBase
    {
        public int Vote { get; set; }

        public string Comment { get; set; }

        public ProductBase Product { get; set; }

        public UserBase User { get; set; }
    }
}
