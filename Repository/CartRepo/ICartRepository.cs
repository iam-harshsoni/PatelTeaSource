using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.CartRepo
{
    public interface ICartRepository
    {
        long Add(cart_master cart);

        cart_master SelectById(long? Id);
        IQueryable<cart_master> SelectByCartID(long ID);

        IQueryable<cart_master> SelectByUserID(long ID);

        IQueryable<cart_master> SelectAll();
        void Update(cart_master cart);
        void Delete(int id);
    }
}