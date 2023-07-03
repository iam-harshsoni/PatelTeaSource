using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.ProductMasterRepo
{
    public class ProductMasterRepository :IProductMasterRepository
    {
        EcommerceEntities _entities;
        public ProductMasterRepository()
        {
            _entities = new EcommerceEntities();
        }
        public long Add(product_master product)
        {
            _entities.product_master.Add(product);
            _entities.SaveChanges();

            return product.p_id;
        }

        public product_master SelectById(long? Id)
        {
            return _entities.product_master.Where(x => x.p_id == Id).FirstOrDefault();
        }

        public IQueryable<product_master> SelectByProductID(long ID)
        {
            return _entities.product_master.Where(x => x.p_id == ID);
        }
        public IQueryable<product_master> SelectAll()
        {
            return _entities.product_master;
        }
        public void Update(product_master product)
        {
            _entities.SaveChanges();
        }
        public void Delete(int id)
        {
            var data = _entities.product_master.Where(t => t.p_id == id).FirstOrDefault();
            _entities.product_master.Remove(data);
            _entities.SaveChanges();

        }
    }
}