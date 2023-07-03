using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PatelTeaSource.Model;


namespace PatelTeaSource.Repository.DistributerMasterRepo
{
    public interface IDistributerMasterRepository
    {
        long Add(distibuter_master distributer);

        distibuter_master SelectById(long? Id);
        IQueryable<distibuter_master> SelectByDistributerID(long ID);

        IQueryable<distibuter_master> SelectAll();
        void Update(distibuter_master contact);
        void Delete(int id);
    }
}