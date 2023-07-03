using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.FeedBackRepo
{
    public interface IFeedbackRepository
    {
        long Add(feedback_master feedback);

        feedback_master SelectById(long? Id);
        IQueryable<feedback_master> SelectByFeedID(long ID);

        IQueryable<feedback_master> SelectAll();
        void Update(feedback_master feedback);
        void Delete(int id);
    }
}