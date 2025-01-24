﻿using Mailo.Data;
using Mailo.Data.Enums;
using Mailo.IRepo;
using Mailo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mailo.Repo
{
    public class CartRepo : ICartRepo
    {
        private readonly AppDbContext _db;
        public CartRepo(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Order?> GetOrCreateCart(User user)
        {
            var cart = await _db.Orders
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.product)
                .FirstOrDefaultAsync(o => o.UserID == user.ID && o.OrderStatus == OrderStatus.New);

            return cart;
        }

        public async Task<List<Product>> GetProducts(Order order)
        {
            return await _db.OrderProducts.Where(op => op.OrderID == order.ID)
                .Select(op => op.product)
                .ToListAsync();
        }
        public async Task<OrderProduct> IsMatched(Order order, int id,Sizes size)
        {
            return await _db.OrderProducts.FirstOrDefaultAsync(op => op.OrderID == order.ID && op.ProductID == id && op.Sizes==size);
        }

        //public async Task<Order> GetOrder(User user)
        //{
        //    Order? order = await _db.Orders.FirstOrDefaultAsync(o => new { o.UserID == user.ID && o.OrderStatus == OrderStatus.New });
        //        if (order == null)
        //        {
        //            order = new Order { OrderPrice = 0, OrderAddress = user.Address, UserID = user.ID
        //};
        //_db.Orders.Add(order);
        //            _db.SaveChanges();
        //        }

        //    return order;
        //}
        public async Task<Order> GetOrder(User user)
        {
            return await _db.Orders.Include(o=>new{o.Payment, o.employee,o.user } ).FirstOrDefaultAsync(o => o.UserID == user.ID && o.OrderStatus == OrderStatus.New);

        }
        public async Task<List<Order>> GetOrders(User user)
        {

            return _db.Orders.Where(o => o.UserID == user.ID && (o.OrderStatus == OrderStatus.Pending || o.OrderStatus == OrderStatus.Shipped)).ToList();

        }
        public async Task<OrderProduct> ExistingCartItem(int productId,Sizes size, User user)
        {
            return await IsMatched(await GetOrder(user), productId,size);
        }
        public async void InsertToCart(int OrderId, int ProductId, Sizes size)
        {
            OrderProduct op = new OrderProduct
            {
                OrderID = OrderId,
                ProductID = ProductId,
                Sizes = size
            };

            await _db.OrderProducts.AddAsync(op);
            _db.SaveChanges();
        }
        public async void DeleteFromCart(int OrderId, int ProductId,Sizes size)
        {
            OrderProduct op = new OrderProduct
            {
                OrderID = OrderId,
                ProductID = ProductId,
                Sizes = size
            };
            _db.OrderProducts.Remove(op);
            _db.SaveChanges();
        }
    }
}