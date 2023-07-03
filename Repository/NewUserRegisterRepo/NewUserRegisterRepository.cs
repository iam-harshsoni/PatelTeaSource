using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.NewUserRegisterRepo
{
    public class NewUserRegisterRepository :INewUserRegisterRepository
    {
        patelteaEntities _entities;
        public NewUserRegisterRepository()
        {
            _entities = new patelteaEntities();
        }
        public long Add(NewUserRegister newUser)
        {
            _entities.NewUserRegisters.Add(newUser);
            _entities.SaveChanges();

            return newUser.userId;
        }

        public NewUserRegister SelectById(long? Id)
        {
            return _entities.NewUserRegisters.Where(x => x.userId == Id).FirstOrDefault();
        }

        public NewUserRegister SelectByUserNamePwd(string userName, string pwd)
        {
            return _entities.NewUserRegisters.Where(x => x.username == userName && x.password==pwd).FirstOrDefault();
        }

        public IQueryable<NewUserRegister> SelectByUserID(long ID)
        {
            return _entities.NewUserRegisters.Where(x => x.userId == ID);
        }
        public IQueryable<NewUserRegister> SelectAll()
        {
            return _entities.NewUserRegisters;
        }
        public void Update(NewUserRegister newUser)
        {
            _entities.SaveChanges();
        }
        public void Delete(int id)
        {
            var data = _entities.NewUserRegisters.Where(t => t.userId == id).FirstOrDefault();
            _entities.NewUserRegisters.Remove(data);
            _entities.SaveChanges();

        }

    }
}