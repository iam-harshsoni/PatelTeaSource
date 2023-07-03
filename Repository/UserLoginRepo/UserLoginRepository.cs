using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.UserLoginRepo
{
    public class UserLoginRepository : IUserLoginRepository
    {
        EcommerceEntities _entities;
        public UserLoginRepository()
        {
            _entities = new EcommerceEntities();
        }
        public long Add(login_master uLogin)
        {
            _entities.login_master.Add(uLogin);
            _entities.SaveChanges();

            return uLogin.login_id;
        }

        public login_master SelectById(long? Id)
        {
            return _entities.login_master.Where(x => x.login_id == Id).FirstOrDefault();
        }

        public IQueryable<login_master> SelectByULoginID(long ID)
        {
            return _entities.login_master.Where(x => x.login_id == ID);
        }
        public IQueryable<login_master> SelectAll()
        {
            return _entities.login_master;
        }
        public void Update(login_master uLogin)
        {
            _entities.SaveChanges();
        }
        public void Delete(int id)
        {
            var data = _entities.login_master.Where(t => t.login_id == id).FirstOrDefault();
            _entities.login_master.Remove(data);
            _entities.SaveChanges();

        }
        public login_master SelectByUserNamePwd(string userName, string pwd)
        {
            return _entities.login_master.Where(x => x.username == userName && x.password == pwd).FirstOrDefault();
        }

    }
}