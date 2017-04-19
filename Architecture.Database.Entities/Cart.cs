using Architecture.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Database.Entities
{
    public class Cart : IEntity // AKA ProductUser
    {
        public int Id { get; set; }

        public double Quantity { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
