using Architecture.Database.Entities;
using Architecture.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Architecture.Mappers.ProductMapper
{
    public class ProductRatingsResolver : IValueResolver<Product, ProductFull, IEnumerable<RatingBase>>
    {
        public IEnumerable<RatingBase> Resolve(Product source, ProductFull destination, IEnumerable<RatingBase> destMember, ResolutionContext context)
        {
            return
                source
                    .Ratings
                    .Select(
                        r =>
                            new RatingBase
                            {
                                Comment = r.Comment,
                                Vote = r.Vote,
                                
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
