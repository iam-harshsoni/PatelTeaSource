using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.OrderMasterRepo
{
    public interface IOrderMasterRepository
    {
        long Add(order_master orderMaster);

        order_master SelectById(long? Id);
        IQueryable<order_master> SelectByOrderID(long ID);

        IQueryable<order_master> SelectAll();
        void Update(order_master orderMaster);
        void Delete(int id);
    }
}