using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.NewUserRegisterRepo
{
    public interface INewUserRegisterRepository
    {
        long Add(NewUserRegister newUser);

        NewUserRegister SelectById(long? Id);
        NewUserRegister SelectByUserNamePwd(string userName,string pwd);
        IQueryable<NewUserRegister> SelectByUserID(long ID);

        IQueryable<NewUserRegister> SelectAll();
        void Update(NewUserRegister newUser);
        void Delete(int id);

        
    }
}