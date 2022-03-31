using IRunes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRunes.Abstarctions
{
    public interface IOrderService
    {
        bool Create(int albumId, int countAlbums);
        bool Update(int orderId, int albumId, int countAlbums);
        List<Order> GetOrders();
        Order GetOrderById(int orderId);
        bool RemoveById(int orderId);
    }
}
