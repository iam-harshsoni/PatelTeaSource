using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.OrderMasterPaymentRepo
{
    public class OrderMasterPaymentRepository : IOrderMasterPaymentRepository
    {
        EcommerceEntities _entities;
        public OrderMasterPaymentRepository()
        {
            _entities = new EcommerceEntities();
        }
        public long Add(order_master_payment orderMasterPayment)
        {
            _entities.order_master_payment.Add(orderMasterPayment);
            _entities.SaveChanges();

            return orderMasterPayment.order_payment_id;
        }

        public order_master_payment SelectById(long? Id)
        {
            return _entities.order_master_payment.Where(x => x.order_payment_id == Id).FirstOrDefault();
        }

        public IQueryable<order_master_payment> SelectByOrderMasterPaymentID(long ID)
        {
            return _entities.order_master_payment.Where(x => x.order_id == ID);
        }
        public IQueryable<order_master_payment> SelectAll()
        {
            return _entities.order_master_payment;
        }
        public void Update(order_master_payment orderMasterPayment)
        {
            _entities.SaveChanges();
        }
        public void Delete(int id)
        {
            var data = _entities.order_master_payment.Where(t => t.order_id == id).FirstOrDefault();
            _entities.order_master_payment.Remove(data);
            _entities.SaveChanges();

        }
    }
}