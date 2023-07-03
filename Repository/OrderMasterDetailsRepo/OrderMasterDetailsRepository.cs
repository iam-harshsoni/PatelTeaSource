using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.OrderMasterDetailsRepo
{
    public class OrderMasterDetailsRepository : IOrderMasterDetailsRepository
    {
        EcommerceEntities _entities;
        public OrderMasterDetailsRepository()
        {
            _entities = new EcommerceEntities();
        }
        public long Add(order_master_details orderMasterDetails)
        {
            _entities.order_master_details.Add(orderMasterDetails);
            _entities.SaveChanges();

            return orderMasterDetails.order_detail_id;
        }

        public order_master_details SelectById(long? Id)
        {
            return _entities.order_master_details.Where(x => x.order_detail_id == Id).FirstOrDefault();
        }

        public IQueryable<order_master_details> SelectByOrderMasterDetailsID(long ID)
        {
            return _entities.order_master_details.Where(x => x.order_id == ID);
        }
        public IQueryable<order_master_details> SelectAll()
        {
            return _entities.order_master_details;
        }
        public void Update(order_master_details orderMasterDetails)
        {
            _entities.SaveChanges();
        }
        public void Delete(int id)
        {
            var data = _entities.order_master_details.Where(t => t.order_detail_id == id).FirstOrDefault();
            _entities.order_master_details.Remove(data);
            _entities.SaveChanges();

        }
    }
}