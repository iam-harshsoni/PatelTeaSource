using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.ShippingAddressRepo
{
    public interface IShippingAddressRepository
    {
        long Add(shipping_address_master shippingAddressMaster);

        shipping_address_master SelectById(long? Id);
        IQueryable<shipping_address_master> SelectByShippingAddressMasterID(long ID);

        IQueryable<shipping_address_master> SelectAll();
        void Update(shipping_address_master shippingAddressMaster);
        void Delete(int id);
    }
}