using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PatelTeaSource.Model;


namespace PatelTeaSource.Repository.DistributerMasterRepo
{
    public class DistributerMasterRepository : IDistributerMasterRepository
    {
        patelteaEntities _entities;
        public DistributerMasterRepository()
        {
            _entities = new patelteaEntities();
        }
        public long Add(distibuter_master distributer)
        {
            _entities.distibuter_master.Add(distributer);
            _entities.SaveChanges();

            return distributer.dis_id;
        }

        public distibuter_master SelectById(long? Id)
        {
            return _entities.distibuter_master.Where(x => x.dis_id == Id).FirstOrDefault();
        }

        public IQueryable<distibuter_master> SelectByDistributerID(long ID)
        {
            return _entities.distibuter_master.Where(x => x.dis_id == ID);
        }
        public IQueryable<distibuter_master> SelectAll()
        {
            return _entities.distibuter_master;
        }
        public void Update(distibuter_master contact)
        {
            _entities.SaveChanges();
        }
        public void Delete(int id)
        {
            var data = _entities.distibuter_master.Where(t => t.dis_id == id).FirstOrDefault();
            _entities.distibuter_master.Remove(data);
            _entities.SaveChanges();

        }

    }
}