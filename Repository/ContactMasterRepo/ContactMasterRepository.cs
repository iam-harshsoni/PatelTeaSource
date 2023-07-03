using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PatelTeaSource.Model;

namespace PatelTeaSource.Repository.ContactMasterRepo
{
    public class ContactMasterRepository : IContactMasterRepository
    {
        patelteaEntities _entities;
        public ContactMasterRepository()
        {
            _entities = new patelteaEntities();
        }
        public long Add(contact_master contact)
        {
            _entities.contact_master.Add(contact);
            _entities.SaveChanges();

            return contact.contact_id;
        }

        public contact_master SelectById(long? Id)
        {
            return _entities.contact_master.Where(x => x.contact_id == Id).FirstOrDefault();
        }

        public IQueryable<contact_master> SelectByBannerID(long ID)
        {
            return _entities.contact_master.Where(x => x.contact_id == ID);
        }
        public IQueryable<contact_master> SelectAll()
        {
            return _entities.contact_master;
        }
        public void Update(contact_master contact)
        {
            _entities.SaveChanges();
        }
        public void Delete(int id)
        {
            var data = _entities.contact_master.Where(t => t.contact_id == id).FirstOrDefault();
            _entities.contact_master.Remove(data);
            _entities.SaveChanges();

        }   

    }
}