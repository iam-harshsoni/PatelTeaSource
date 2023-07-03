using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.OfferSchemeRepo
{
    public class OfferSchemeRepository : IOfferSchemeRepository
    {
        EcommerceEntities _entities;
        public OfferSchemeRepository()
        {
            _entities = new EcommerceEntities();
        }
        public long Add(offerScheme offer)
        {
            _entities.offerSchemes.Add(offer);
            _entities.SaveChanges();

            return offer.offerId;
        }

        public offerScheme SelectById(long? Id)
        {
            return _entities.offerSchemes.Where(x => x.offerId == Id).FirstOrDefault();
        }

        public IQueryable<offerScheme> SelectByOfferID(long ID)
        {
            return _entities.offerSchemes.Where(x => x.offerId== ID);
        }
        public IQueryable<offerScheme> SelectAll()
        {
            return _entities.offerSchemes;
        }
        public void Update(offerScheme offer)
        {
            _entities.SaveChanges();
        }
        public void Delete(int id)
        {
            var data = _entities.offerSchemes.Where(t => t.offerId== id).FirstOrDefault();
            _entities.offerSchemes.Remove(data);
            _entities.SaveChanges();

        }
    }
}