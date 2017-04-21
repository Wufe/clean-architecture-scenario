using Architecture.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Architecture.Database.Entities.Shared
{
    public class Rating : IEntity
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        public int ProductId { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public int Vote { get; set; }

        public string Comment { get; set; }
    }
}
