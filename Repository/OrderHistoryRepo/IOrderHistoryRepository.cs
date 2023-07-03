using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.OrderHistoryRepo
{
    public interface IOrderHistoryRepository
    {
        long Add(order_history orderHistory);
        order_history SelectById(long? Id);
        IQueryable<order_history> SelectByOrderHistoryId(long ID);
        IQueryable<order_history> SelectAll();
        void Update(order_history orderHistory);
        void Delete(int id);
    }
}