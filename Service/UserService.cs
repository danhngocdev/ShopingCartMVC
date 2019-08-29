using System;
using Service.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repository.Interface;
using DAL;
using Repository;

namespace Service
{
    public class UserService :  IServices<User>
    {
        private IRepository<User> repository;
        public UserService()
        {
            repository = new UserReponsitory(new DBEntityContext());
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

     

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetByUserName(string UserName)
        {
            return repository.GetByUserName(UserName);
        }

        public Contact GetContact()
        {
            throw new NotImplementedException();
        }

        public int Insert(User t)
        {
            return repository.Insert(t);
        }

        public IEnumerable<User> ListProductHot()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> ListProductNew()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> ListProductSale()
        {
            throw new NotImplementedException();
        }

        public bool Login(string username, string password)
        {
            return repository.Login(username, password);
        }

		public IEnumerable<User> Search(string searchString, int Page, int Pagesize)
		{
			throw new NotImplementedException();
		}

		public int Update(User t)
        {
            throw new NotImplementedException();
        }
    }
}
