using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PatelTeaSource.Model;

namespace PatelTeaSource.Repository.AwardsRepo
{
    public class AwardsRepository : IAwardsRepository
    {
        patelteaEntities _entities;
        public AwardsRepository()
        {
            _entities = new patelteaEntities();
        }
        public long Add(awardsCertificate awards)
        {
            _entities.awardsCertificates.Add(awards);
            _entities.SaveChanges();

            return awards.awardId;
        }

        public awardsCertificate SelectById(long? Id)
        {
            return _entities.awardsCertificates.Where(x => x.awardId == Id).FirstOrDefault();
        }

        public IQueryable<awardsCertificate> SelectByAwardID(long ID)
        {
            return _entities.awardsCertificates.Where(x => x.awardId == ID);
        }
        public IQueryable<awardsCertificate> SelectAll()
        {
            return _entities.awardsCertificates;
        }
        public void Update(awardsCertificate awards)
        {
            _entities.SaveChanges();
        }
        public void Delete(int id)
        {
            var data = _entities.awardsCertificates.Where(t => t.awardId == id).FirstOrDefault();
            _entities.awardsCertificates.Remove(data);
            _entities.SaveChanges();

        }
    }
}