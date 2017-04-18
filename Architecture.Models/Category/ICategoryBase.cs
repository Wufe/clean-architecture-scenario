using Architecture.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Models.Category
{
    public interface ICategoryBase : IEntity
    {
        string Title { get; set; }
    }
}
