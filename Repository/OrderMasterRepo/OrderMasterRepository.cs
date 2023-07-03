using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.OrderMasterRepo
{
    public class OrderMasterRepository : IOrderMasterRepository
    {
        EcommerceEntities _entities;
        public OrderMasterRepository()
        {
            _entities = new EcommerceEntities();
        }
        public long Add(order_master orderMaster)
        {
            _entities.order_master.Add(orderMaster);
            _entities.SaveChanges();

            return orderMaster.order_id;
        }

        public order_master SelectById(long? Id)
        {
            return _entities.order_master.Where(x => x.order_id == Id).FirstOrDefault();
        }

        public IQueryable<order_master> SelectByOrderID(long ID)
        {
            return _entities.order_master.Where(x => x.order_id == ID);
        }
        public IQueryable<order_master> SelectAll()
        {
            return _entities.order_master;
        }
        public void Update(order_master orderMaster)
        {
            _entities.SaveChanges();
        }
        public void Delete(int id)
        {
            var data = _entities.order_master.Where(t => t.order_id == id).FirstOrDefault();
            _entities.order_master.Remove(data);
            _entities.SaveChanges();

        }
    }
}