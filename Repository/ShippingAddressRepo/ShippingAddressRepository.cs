using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.ShippingAddressRepo
{
    public class ShippingAddressRepository : IShippingAddressRepository
    {
        EcommerceEntities _entities;
        public ShippingAddressRepository()
        {
            _entities = new EcommerceEntities();
        }
        public long Add(shipping_address_master shippingAddressMaster)
        {
            _entities.shipping_address_master.Add(shippingAddressMaster);
            _entities.SaveChanges();

            return shippingAddressMaster.shipping_id;
        }

        public shipping_address_master SelectById(long? Id)
        {
            return _entities.shipping_address_master.Where(x => x.shipping_id == Id).FirstOrDefault();
        }

        public IQueryable<shipping_address_master> SelectByShippingAddressMasterID(long ID)
        {
            return _entities.shipping_address_master.Where(x => x.shipping_id == ID);
        }
        public IQueryable<shipping_address_master> SelectAll()
        {
            return _entities.shipping_address_master;
        }
        public void Update(shipping_address_master shippingMaster)
        {
            _entities.SaveChanges();
        }
        public void Delete(int id)
        {
            var data = _entities.shipping_address_master.Where(t => t.shipping_id == id).FirstOrDefault();
            _entities.shipping_address_master.Remove(data);
            _entities.SaveChanges();

        }
    }
}