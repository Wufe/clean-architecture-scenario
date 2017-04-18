using Architecture.Models.Interfaces;
using Architecture.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Models.Rating
{
    public interface IRatingBase : IEntity
    {
        int Vote { get; set; }

        string Comment { get; set; }

        int ProductId { get; set; }

        UserBase User { get; set; }
    }
}
