using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.BlogRepo
{
    public interface IBlogRepository
    {
        long Add(blog_master blog);

        blog_master SelectById(long? Id);
        IQueryable<blog_master> SelectByblogID(long ID);

        IQueryable<blog_master> SelectAll();
        void Update(blog_master blog);
        void Delete(int id);
    }
}