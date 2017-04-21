using Architecture.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Architecture.Database.Entities.Shared
{
    /// <summary>
    /// Represents an item in a cart.
    /// Many to many relationship between Product and User.
    /// </summary>
    public class ProductUser : IEntity
    {
        public int Id { get; set; }

        public double Quantity { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
