using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PatelTeaSource.Model;

namespace PatelTeaSource.Repository.BannerMasterRepo
{
    public class BannerMasterRepository : IBannerMasterRepository
    {
        patelteaEntities _entities;
        public BannerMasterRepository()
        {
            _entities = new patelteaEntities();
        }
        public long Add(banner_master bannerMaster)
        {
            _entities.banner_master.Add(bannerMaster);
            _entities.SaveChanges();

            return bannerMaster.banner_id;
        }

        public banner_master SelectById(long? Id)
        {
            return _entities.banner_master.Where(x => x.banner_id == Id).FirstOrDefault();
        }

        public IQueryable<banner_master> SelectByBannerID(long ID)
        {
            return _entities.banner_master.Where(x => x.banner_id == ID);
        } 
        public IQueryable<banner_master> SelectAll()
        {
            return _entities.banner_master;
        }
        public void Update(banner_master banner)
        {
            _entities.SaveChanges();
        }
        public void Delete(int id)
        {
            var data = _entities.banner_master.Where(t => t.banner_id == id).FirstOrDefault();
            _entities.banner_master.Remove(data);
            _entities.SaveChanges();

        }
         
    }
}