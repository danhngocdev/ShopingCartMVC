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
    public class ProductRepository : IRepository<Product>
    {
        private DBEntityContext context;
        public ProductRepository(DBEntityContext context)
        {
            this.context = context;
        }
        public int Delete(int id)
        {
            var item = context.Products.Where(c => c.Id == id).SingleOrDefault();
            context.Products.Remove(item);
            return context.SaveChanges();
        }

        public IEnumerable<Product> Filter(Product t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public Product GetById(int id)
        {
         return   context.Products.Where(x => x.Id == id).SingleOrDefault();
        }

        public Product GetByUserName(string UserName)
        {
            throw new NotImplementedException();
        }

        public int Insert(Product t)
        {
            context.Products.Add(t);
            return context.SaveChanges();
        }

		public IEnumerable<Product> ListProductHot()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Product> ListProductNew()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Product> ListProductSale()
		{
			throw new NotImplementedException();
		}

		public bool Login(string username, string password)
		{
			throw new NotImplementedException();
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

        public int Update(Product t)
        {
            context.Entry(t).State = System.Data.Entity.EntityState.Modified;
            return context.SaveChanges();
        }
    }
}
