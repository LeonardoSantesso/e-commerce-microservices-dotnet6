﻿using AutoMapper;
using GeekShopping.CouponAPI.Data.ValueObjects;
using GeekShopping.CouponAPI.Model.Context;
using GeekShopping.CouponAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CouponAPI.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public CouponRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CouponVO> GetCouponByCouponCode(string couponCode)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.CouponCode == couponCode);
            return _mapper.Map<CouponVO>(coupon);
        }
    }
}
