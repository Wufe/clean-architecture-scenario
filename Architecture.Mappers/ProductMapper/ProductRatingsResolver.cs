using Architecture.Database.Entities;
using Architecture.Models.Product;
using Architecture.Models.Rating;
using Architecture.Models.User;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Architecture.Mappers.ProductMapper
{
    public class ProductRatingsResolver : IValueResolver<Product, IProductFull, IEnumerable<RatingBase>>
    {
        public IEnumerable<RatingBase> Resolve(Product source, IProductFull destination, IEnumerable<RatingBase> destMember, ResolutionContext context)
        {
            return
                source
                    .Ratings
                    .Select(
                        r =>
                            new RatingBase
                            {
                                Id = r.Id,
                                Comment = r.Comment,
                                Vote = r.Vote,
                                Product = new ProductBase
                                {
                                    Id = source.Id,
                                    Name = source.Name,
                                    Description = source.Description,
                                    Price = source.Price
                                },
                                User = new UserBase
                                {
                                    Id = r.User.Id,
                                    UserName = r.User.UserName
                                },

                            }
                    );
        }
    }
}
