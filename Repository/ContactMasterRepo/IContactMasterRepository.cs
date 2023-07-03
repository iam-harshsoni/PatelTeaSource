using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PatelTeaSource.Model;

namespace PatelTeaSource.Repository.ContactMasterRepo
{
    public interface IContactMasterRepository
    {
        long Add(contact_master contact);

        contact_master SelectById(long? Id);
        IQueryable<contact_master> SelectByBannerID(long ID);

        IQueryable<contact_master> SelectAll();
        void Update(contact_master contact);
        void Delete(int id);

    }
}