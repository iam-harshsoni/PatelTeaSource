using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.ProductMasterRepo
{
    public interface IProductMasterRepository
    {
        long Add(product_master product);

        product_master SelectById(long? Id);
        IQueryable<product_master> SelectByProductID(long ID);

        IQueryable<product_master> SelectAll();
        void Update(product_master product);
        void Delete(int id);
    }
}