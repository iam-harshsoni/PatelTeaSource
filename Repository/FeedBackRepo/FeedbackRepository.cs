using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.FeedBackRepo
{
    public class FeedbackRepository : IFeedbackRepository
    {
        patelteaEntities _entities;
        public FeedbackRepository()
        {
            _entities = new patelteaEntities();
        }
        public long Add(feedback_master feedback)
        {
            _entities.feedback_master.Add(feedback);
            _entities.SaveChanges();

            return feedback.feed_id;
        }

        public feedback_master SelectById(long? Id)
        {
            return _entities.feedback_master.Where(x => x.feed_id == Id).FirstOrDefault();
        }

        public IQueryable<feedback_master> SelectByFeedID(long ID)
        {
            return _entities.feedback_master.Where(x => x.feed_id == ID);
        }
        public IQueryable<feedback_master> SelectAll()
        {
            return _entities.feedback_master;
        }
        public void Update(feedback_master feed)
        {
            _entities.SaveChanges();
        }
        public void Delete(int id)
        {
            var data = _entities.feedback_master.Where(t => t.feed_id == id).FirstOrDefault();
            _entities.feedback_master.Remove(data);
            _entities.SaveChanges();

        }
    }
}