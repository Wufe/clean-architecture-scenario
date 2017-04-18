using Architecture.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Models.Rating
{
    public class RatingBase : IRatingBase
    {
        public int Id { get; set; }

        public int Vote { get; set; }

        public string Comment { get; set; }

        public int ProductId { get; set; }

        public UserBase User { get; set; }
    }
}
