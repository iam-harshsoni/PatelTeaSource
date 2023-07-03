
using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.CartRepo
{
    public class CartRepository : ICartRepository
    {
        EcommerceEntities _entities;
        public CartRepository()
        {
            _entities = new EcommerceEntities();
        }
        public long Add(cart_master cart)
        {
            _entities.cart_master.Add(cart);
            _entities.SaveChanges();

            return cart.cart_id;
        }

        public cart_master SelectById(long? Id)
        {
            return _entities.cart_master.Where(x => x.cart_id== Id).FirstOrDefault();
        }

        public IQueryable<cart_master> SelectByCartID(long ID)
        {
            return _entities.cart_master.Where(x => x.cart_id== ID);
        } 
        public IQueryable<cart_master> SelectByUserID(long ID)
        {
            return _entities.cart_master.Where(x => x.user_id == ID);
        }
        public IQueryable<cart_master> SelectAll()
        {
            return _entities.cart_master;
        }
        public void Update(cart_master cart)
        {
            _entities.SaveChanges();
        }
        public void Delete(int id)
        {
            var data = _entities.cart_master.Where(t => t.cart_id== id).FirstOrDefault();
            _entities.cart_master.Remove(data);
            _entities.SaveChanges();
        }
    }
}