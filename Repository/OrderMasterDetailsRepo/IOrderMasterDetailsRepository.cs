using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.OrderMasterDetailsRepo
{
    public interface IOrderMasterDetailsRepository
    {
        long Add(order_master_details orderMasterDetails);
        order_master_details SelectById(long? Id);
        IQueryable<order_master_details> SelectByOrderMasterDetailsID(long ID);
        IQueryable<order_master_details> SelectAll();
        void Update(order_master_details orderMasterDetails);
        void Delete(int id);
    }
}