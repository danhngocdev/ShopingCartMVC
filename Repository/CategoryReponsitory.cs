using DAL;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryReponsitory : IRepository<Category>, IDisposable
    {
        private DBEntityContext context;
        public CategoryReponsitory(DBEntityContext context)
        {
            this.context = context;
        }

        public int Delete(int id)
        {
            var item = context.Categories.Where(c => c.ID == id).SingleOrDefault();
            context.Categories.Remove(item);
            return context.SaveChanges();
        }

        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Category> Filter(Category t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            return context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return context.Categories.Where(c => c.ID == id).SingleOrDefault();
        }

        public int Insert(Category t)
        {
            context.Categories.Add(t);
            return context.SaveChanges();
        }

        public IEnumerable<Category> Search(string searchString)
        {
            throw new NotImplementedException();
        }

        public int Update(Category t)
        {
            context.Entry(t).State = System.Data.Entity.EntityState.Modified;
            return context.SaveChanges();
        }

        

        public Category GetByUserName(string UserName)
        {
            throw new NotImplementedException();
        }

        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
