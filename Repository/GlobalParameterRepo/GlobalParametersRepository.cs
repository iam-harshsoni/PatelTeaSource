using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.GlobalParameterRepo
{
    public class GlobalParametersRepository : IGlobalParametersRepository
    {
        patelteaEntities _entities;
        public GlobalParametersRepository()
        {
            _entities = new patelteaEntities();
        }
        public long Add(GlobalParameter param)
        {
            _entities.GlobalParameters.Add(param);
            _entities.SaveChanges();

            return param.gId;
        }

        public GlobalParameter SelectById(long? Id)
        {
            return _entities.GlobalParameters.Where(x => x.gId == Id).FirstOrDefault();
        }

        public IQueryable<GlobalParameter> SelectByParamID(long ID)
        {
            return _entities.GlobalParameters.Where(x => x.gId == ID);
        }
        public IQueryable<GlobalParameter> SelectAll()
        {
            return _entities.GlobalParameters;
        }
        public void Update(GlobalParameter param)
        {
            _entities.SaveChanges();
        }
        public void Delete(int id)
        {
            var data = _entities.GlobalParameters.Where(t => t.gId == id).FirstOrDefault();
            _entities.GlobalParameters.Remove(data);
            _entities.SaveChanges();

        }
    }
}