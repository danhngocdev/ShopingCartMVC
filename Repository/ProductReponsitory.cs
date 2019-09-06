using DAL;
using Model;
using PagedList;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductReponsitory : IRepository<Product>, IDisposable
    {
        private DBEntityContext context;
        public ProductReponsitory(DBEntityContext context)
        {
            this.context = context;
        }
        public int Delete(int id)
        {
            var item = context.Products.Where(c => c.Id == id).SingleOrDefault();
            if (item.Status == false)
            {
                context.Products.Remove(item);
                context.SaveChanges();
            }
            return 0;
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

  

        public IEnumerable<Product> GetAll()
        {
            return context.Products.Where(s=>s.Status == true).ToList();
        }

        public Product GetById(int id)
        {
            return context.Products.Where(s => s.Id == id).SingleOrDefault();
        }

        public Product GetByUserName(string UserName)
        {
            throw new NotImplementedException();
        }

        public int Insert(Product product)
        {
			product.Created = DateTime.Now;
            context.Products.Add(product);
            return context.SaveChanges();
        }

        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Search(string searchString)
        {
            throw new NotImplementedException();
        }

        public int Update(Product t)
        {
			t.ModifileDate = DateTime.Now;
            context.Entry(t).State = System.Data.Entity.EntityState.Modified;
            return context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Product> ListProductHot()
        {
            return context.Products.Where(s => s.TopHot == true && s.Status == true).OrderByDescending(s => s.Created).Take(8).ToList();
        }

        public IEnumerable<Product> ListProductSale()
        {
            return context.Products.ToList();
        }
       

        public IEnumerable<Product> ListProductNew()
        {
            return context.Products.Where(s => s.Status == true).OrderByDescending(s => s.Created).Take(8).ToList();
        }

		public IEnumerable<Product> Search(string searchString, int Page, int Pagesize)
		{
			var model = context.Products.ToList();
			if (!string.IsNullOrEmpty(searchString))
			{
				model = model.Where(x => x.Name.Contains(searchString)).ToList();
			}
			return model.OrderByDescending(x => x.Created).ToPagedList(Page, Pagesize);
		}

        public Contact GetContact()
        {
            throw new NotImplementedException();
        }
    }
}
