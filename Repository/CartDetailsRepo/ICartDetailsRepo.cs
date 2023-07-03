using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.CartDetailsRepo
{
    public interface ICartDetailsRepo
    {
        long Add(cart_master_details cartDetails);

        cart_master_details SelectById(long? Id);
        IQueryable<cart_master_details> SelectByCartDetailsID(long ID);

        IQueryable<cart_master_details> SelectByCartID(long ID);

        IQueryable<cart_master_details> SelectAll();
        void Update(cart_master_details cartDetails);
        void Delete(int id);
    }
}