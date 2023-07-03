using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.PasswordRecoveryRepo
{
    public class PasswordRecoveryRepository : IPasswordRecoveryRepository
    {
        EcommerceEntities _entities;
        public PasswordRecoveryRepository()
        {
            _entities = new EcommerceEntities();
        }
        public long Add(pwd_Recovery pwdRecovery)
        {
            _entities.pwd_Recovery.Add(pwdRecovery);
            _entities.SaveChanges();

            return pwdRecovery.Id;
        }

        public pwd_Recovery SelectById(long? Id)
        {
            return _entities.pwd_Recovery.Where(x => x.Id== Id).FirstOrDefault();
        }

        public IQueryable<pwd_Recovery> SelectByPwdRecoveryID(long ID)
        {
            return _entities.pwd_Recovery.Where(x => x.Id== ID);
        }
        public IQueryable<pwd_Recovery> SelectAll()
        {
            return _entities.pwd_Recovery;
        }
        public void Update(pwd_Recovery pwdRecovery)
        {
            _entities.SaveChanges();
        }
        public void Delete(int id)
        {
            var data = _entities.pwd_Recovery.Where(t => t.Id== id).FirstOrDefault();
            _entities.pwd_Recovery.Remove(data);
            _entities.SaveChanges();

        }
    }
}