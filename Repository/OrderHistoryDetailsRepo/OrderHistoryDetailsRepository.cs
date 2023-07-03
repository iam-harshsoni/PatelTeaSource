using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.OrderHistoryDetailsRepo
{
    public class OrderHistoryDetailsRepository : IOrderHistoryDetailsRepository
    {
        EcommerceEntities _entities;
        public OrderHistoryDetailsRepository()
        {
            _entities = new EcommerceEntities();
        }
        public long Add(order_history_details orderHistoryDetails)
        {
            _entities.order_history_details.Add(orderHistoryDetails);
            _entities.SaveChanges();

            return orderHistoryDetails.order_detail_history_id;
        }

        public order_history_details SelectById(long? Id)
        {
            return _entities.order_history_details.Where(x => x.order_detail_history_id == Id).FirstOrDefault();
        }

        public IQueryable<order_history_details> SelectByOrderHistoryDetailsId(long ID)
        {
            return _entities.order_history_details.Where(x => x.order_detail_history_id == ID);
        }
        public IQueryable<order_history_details> SelectAll()
        {
            return _entities.order_history_details;
        }
        public void Update(order_history_details orderHistoryDetails)
        {
            _entities.SaveChanges();
        }
        public void Delete(int id)
        {
            var data = _entities.order_history_details.Where(t => t.order_detail_history_id == id).FirstOrDefault();
            _entities.order_history_details.Remove(data);
            _entities.SaveChanges();

        }
    }
}