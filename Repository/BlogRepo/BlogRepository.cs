using PatelTeaSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Repository.BlogRepo
{
    public class BlogRepository : IBlogRepository
    {
        patelteaEntities _entities;
        public BlogRepository()
        {
            _entities = new patelteaEntities();
        }
        public long Add(blog_master blog)
        {
            _entities.blog_master.Add(blog);
            _entities.SaveChanges();

            return blog.id;
        }

        public blog_master SelectById(long? Id)
        {
            return _entities.blog_master.Where(x => x.id == Id).FirstOrDefault();
        }

        public IQueryable<blog_master> SelectByblogID(long ID)
        {
            return _entities.blog_master.Where(x => x.id == ID);
        }
        public IQueryable<blog_master> SelectAll()
        {
            return _entities.blog_master;
        }
        public void Update(blog_master blog)
        {
            _entities.SaveChanges();
        }
        public void Delete(int id)
        {
            var data = _entities.blog_master.Where(t => t.id == id).FirstOrDefault();
            _entities.blog_master.Remove(data);
            _entities.SaveChanges();

        }
    }
}