using Architecture.Models.Product;
using Architecture.Models.Rating;
using Architecture.Models.User;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Architecture.Mappers.Product
{
    public class ProductRatingsResolver : IValueResolver<Database.Entities.Product, IProductFull, IEnumerable<RatingBase>>
    {
        public IEnumerable<RatingBase> Resolve(Database.Entities.Product source, IProductFull destination, IEnumerable<RatingBase> destMember, ResolutionContext context)
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
                                ProductId = source.Id,
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
