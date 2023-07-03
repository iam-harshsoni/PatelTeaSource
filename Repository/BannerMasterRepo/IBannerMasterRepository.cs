using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PatelTeaSource.Model;

namespace PatelTeaSource.Repository.BannerMasterRepo
{
    public interface IBannerMasterRepository
    {
        long Add(banner_master project);

        banner_master SelectById(long? Id);
        IQueryable<banner_master> SelectByBannerID(long ID);
     
        IQueryable<banner_master> SelectAll();
        void Update(banner_master project);
        void Delete(int id);
        
     

    }
}