using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.UserLoginRepo
{
    public interface IUserLoginRepository
    {
        long Add(login_master uLogin);

        login_master SelectById(long? Id);
        IQueryable<login_master> SelectByULoginID(long ID);
        login_master SelectByUserNamePwd(string userName, string pwd);
        IQueryable<login_master> SelectAll();
        void Update(login_master uLogin);
        void Delete(int id);
    }
}