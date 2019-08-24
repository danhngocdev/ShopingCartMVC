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

        public int Login(LoginModel model, bool isLoginAdmin = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Search(string searchString)
        {
            throw new NotImplementedException();
        }

        public int Update(Product t)
        {
            context.Entry(t).State = System.Data.Entity.EntityState.Modified;
            return context.SaveChanges();
        }
    }
}
