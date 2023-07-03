using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.UserMasterRepo
{
    public interface IUserMasterRepository
    {
        long Add(user_master uLogin);

        user_master SelectById(long? Id);
        IQueryable<user_master> SelectByUserID(long ID);

        IQueryable<user_master> SelectAll();
        void Update(user_master userMaster);
        void Delete(int id);
    }
}