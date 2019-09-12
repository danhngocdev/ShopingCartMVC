using DAL;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class WishListReponsitory : IWishListReponsitory<WishList>, IDisposable
    {
        private DBEntityContext context;
        public WishListReponsitory(DBEntityContext context)
        {
            this.context = context;
        }
        public int Delete(int id)
        {
            var item = context.wishLists.SingleOrDefault(c => c.ID == id);
            context.wishLists.Remove(item);
            return context.SaveChanges();
        }

        public IEnumerable<WishList> GetById(int id)
        {
	        return context.wishLists.Where(x => x.UserID.Equals(id)).ToList();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<WishList> GetAll()
        {
            return context.wishLists.ToList();
        }

        public int Insert(WishList t)
        {
            context.wishLists.Add(t);
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
        
    }
}
