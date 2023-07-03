using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PatelTeaSource.Model;

namespace PatelTeaSource.Repository.AwardsRepo
{
    public interface IAwardsRepository
    {
        long Add(awardsCertificate awards);

        awardsCertificate SelectById(long? Id);
        IQueryable<awardsCertificate> SelectByAwardID(long ID);

        IQueryable<awardsCertificate> SelectAll();
        void Update(awardsCertificate awards);
        void Delete(int id);
    }
}