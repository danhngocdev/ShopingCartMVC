using DAL;
using Model;
using Repository;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService : IServices<Product>
    {
        private IRepository<Product> repository;
        public ProductService()
        {
            repository = new ProductRepository(new DBEntityContext());
        }
        public int Delete(int id)
        {
          return  repository.Delete(id);
        }

        public IEnumerable<Product> Filter(Product t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            return repository.GetAll();
        }

        public Product GetById(int id)
        {
            return repository.GetById(id);
        }

        public Product GetByUserName(string UserName)
        {
            throw new NotImplementedException();
        }

        public int Insert(Product t)
        {
            return repository.Insert(t);
        }

     
		public bool Login(string username, string password)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Product> Search(string searchString, int Page, int Pagesize)
        {
			return repository.Search(searchString, Page, Pagesize);
        }

        public int Update(Product t)
        {
            return repository.Update(t);
        }
    }
}
