using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.UserMasterRepo
{
    public class UserMasterRepository : IUserMasterRepository
    {
        EcommerceEntities _entities;
        public UserMasterRepository()
        {
            _entities = new EcommerceEntities();
        }
        public long Add(user_master uLogin)
        {
            _entities.user_master.Add(uLogin);
            _entities.SaveChanges();

            return uLogin.user_id;
        }

        public user_master SelectById(long? Id)
        {
            return _entities.user_master.Where(x => x.user_id == Id).FirstOrDefault();
        }

        public IQueryable<user_master> SelectByUserID(long ID)
        {
            return _entities.user_master.Where(x => x.user_id == ID);
        }
        public IQueryable<user_master> SelectAll()
        {
            return _entities.user_master;
        }
        public void Update(user_master uLogin)
        {
            _entities.SaveChanges();
        }
        public void Delete(int id)
        {
            var data = _entities.user_master.Where(t => t.user_id == id).FirstOrDefault();
            _entities.user_master.Remove(data);
            _entities.SaveChanges();

        }
    }
}