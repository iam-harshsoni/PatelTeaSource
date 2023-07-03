using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.PasswordRecoveryRepo
{
    public interface IPasswordRecoveryRepository
    {
        long Add(pwd_Recovery pwdRecovery);

        pwd_Recovery SelectById(long? Id);
        IQueryable<pwd_Recovery> SelectByPwdRecoveryID(long ID);

        IQueryable<pwd_Recovery> SelectAll();
        void Update(pwd_Recovery pwdRecovery);
        void Delete(int id);
    }
}