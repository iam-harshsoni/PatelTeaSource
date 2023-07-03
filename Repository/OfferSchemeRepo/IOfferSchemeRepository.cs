using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.OfferSchemeRepo
{
    public interface IOfferSchemeRepository
    {
        long Add(offerScheme offer);

        offerScheme SelectById(long? Id);
        IQueryable<offerScheme> SelectByOfferID(long ID);

        IQueryable<offerScheme> SelectAll();
        void Update(offerScheme offer);
        void Delete(int id);
    }
}