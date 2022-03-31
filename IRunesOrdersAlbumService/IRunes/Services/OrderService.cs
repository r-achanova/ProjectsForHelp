using IRunes.Abstarctions;
using IRunes.Data;
using IRunes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRunes.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(int albumId, int countAlbums)
        {
            Order item = new Order
            {
                AlbumId=albumId,
                CountAlbums=countAlbums
            };

            _context.Orders.Add(item);
            return _context.SaveChanges() != 0;
        }

        public Order GetOrderById(int orderId)
        {
            return _context.Orders.Find(orderId);
        }

        public List<Order> GetOrders()
        {
            List<Order> orders = _context.Orders.ToList();
            return orders;
        }

        public bool RemoveById(int orderId)
        {
            var order = GetOrderById(orderId);
            if (order == default(Order))
            {
                return false;
            }
            _context.Remove(order);
            return _context.SaveChanges() != 0;
        }

        public bool Update(int oredrId, int albumId, int countAlbums)
        {
            var order = GetOrderById(albumId);
            if (order == default(Order))
            {
                return false;
            }
            order.AlbumId = albumId;
            order.CountAlbums = countAlbums;
            _context.Update(order);
            return _context.SaveChanges() != 0;
        }
    }
}
