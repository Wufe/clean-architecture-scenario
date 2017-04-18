﻿using Architecture.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Models.Category
{
    public class CategoryBase : IEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}