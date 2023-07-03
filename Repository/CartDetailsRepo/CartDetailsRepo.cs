using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.CartDetailsRepo
{
    public class CartDetailsRepo : ICartDetailsRepo
    {
        EcommerceEntities _entities;
        public CartDetailsRepo()
        {
            _entities = new EcommerceEntities();
        }
        public long Add(cart_master_details cartDetails)
        {
            _entities.cart_master_details.Add(cartDetails);
            _entities.SaveChanges();

            return cartDetails.cart_detail_id;
        }

        public cart_master_details SelectById(long? Id)
        {
            return _entities.cart_master_details.Where(x => x.cart_detail_id == Id).FirstOrDefault();
        }

        public IQueryable<cart_master_details> SelectByCartDetailsID(long ID)
        {
            return _entities.cart_master_details.Where(x => x.cart_detail_id== ID);
        }
        public IQueryable<cart_master_details> SelectByCartID(long ID)
        {
            return _entities.cart_master_details.Where(x => x.cart_id == ID);
        }
        public IQueryable<cart_master_details> SelectAll()
        {
            return _entities.cart_master_details;
        }
        public void Update(cart_master_details cartDetails)
        {
            _entities.SaveChanges();
        }
        public void Delete(int id)
        {
            var data = _entities.cart_master_details.Where(t => t.cart_detail_id == id).FirstOrDefault();
            _entities.cart_master_details.Remove(data);
            _entities.SaveChanges();
        }

    }
}