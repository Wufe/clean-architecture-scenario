using Architecture.Database.Entities.Shared;
using Architecture.Models;
using Architecture.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Architecture.Services
{
    public class CartService : ICartService
    {
        private readonly IProductUserRepository _cartRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public CartService(
            IMapper mapper,
            IProductUserRepository cartRepository,
            IUserService userService
        )
        {
            _mapper = mapper;
            _cartRepository = cartRepository;
            _userService = userService;
        }

        public CartFull GetCart(int userId)
        {
            var productUsers =
                _cartRepository
                    .GetAll()
                    .Where(
                        x =>
                            x.UserId == userId
                    );

            productUsers =
                _cartRepository
                    .WithProducts(productUsers);

            return _mapper.Map<IEnumerable<ProductUser>, CartFull>(productUsers);

        }

        public CartFull GetCart(ClaimsPrincipal userClaim)
        {
            var userId =
                _userService
                    .GetUserIdByClaim(userClaim);
            if (userId == default(int))
                throw new ArgumentNullException("ClaimsPrincipal");
            return GetCart(userId);
        }
    }
}
