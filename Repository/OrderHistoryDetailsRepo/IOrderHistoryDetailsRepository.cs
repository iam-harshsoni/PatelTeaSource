using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.OrderHistoryDetailsRepo
{
    public interface IOrderHistoryDetailsRepository
    {
        long Add(order_history_details orderHistoryDetails);
        order_history_details SelectById(long? Id);
        IQueryable<order_history_details> SelectByOrderHistoryDetailsId(long ID);
        IQueryable<order_history_details> SelectAll();
        void Update(order_history_details orderHistoryDetails);
        void Delete(int id);
    }
}