using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.OrderHistoryRepo
{
    public class OrderHistoryRepository : IOrderHistoryRepository
    {
        EcommerceEntities _entities;
        public OrderHistoryRepository()
        {
            _entities = new EcommerceEntities();
        }
        public long Add(order_history orderHistory)
        {
            _entities.order_history.Add(orderHistory);
            _entities.SaveChanges();

            return orderHistory.order_history_id;
        }

        public order_history SelectById(long? Id)
        {
            return _entities.order_history.Where(x => x.order_history_id== Id).FirstOrDefault();
        }

        public IQueryable<order_history> SelectByOrderHistoryId(long ID)
        {
            return _entities.order_history.Where(x => x.order_history_id == ID);
        }
        public IQueryable<order_history> SelectAll()
        {
            return _entities.order_history;
        }
        public void Update(order_history orderHistory)
        {
            _entities.SaveChanges();
        }
        public void Delete(int id)
        {
            var data = _entities.order_history.Where(t => t.order_history_id == id).FirstOrDefault();
            _entities.order_history.Remove(data);
            _entities.SaveChanges();

        }
    }
}