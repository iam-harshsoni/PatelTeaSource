using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.OrderMasterPaymentRepo
{
    public interface IOrderMasterPaymentRepository
    {
        long Add(order_master_payment orderMasterPayment);
        order_master_payment SelectById(long? Id);
        IQueryable<order_master_payment> SelectByOrderMasterPaymentID(long ID);  
        IQueryable<order_master_payment> SelectAll();
        void Update(order_master_payment orderMasterPayment);
        void Delete(int id);
    }
}