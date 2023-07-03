using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.GlobalParameterRepo
{
    public interface IGlobalParametersRepository
    {
        long Add(GlobalParameter param);

        GlobalParameter SelectById(long? Id);
        IQueryable<GlobalParameter> SelectByParamID(long ID);

        IQueryable<GlobalParameter> SelectAll();
        void Update(GlobalParameter param);
        void Delete(int id);
    }
}