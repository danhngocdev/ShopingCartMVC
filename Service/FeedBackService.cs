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
    public class FeedBackService : IServices<FeedBack>
    {
        private IRepository<FeedBack> repository;
        public FeedBackService()
        {
            repository = new FeedBackReponsitory(new DBEntityContext());
        }
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FeedBack> GetAll()
        {
            throw new NotImplementedException();
        }

        public FeedBack GetById(int id)
        {
            throw new NotImplementedException();
        }

        public FeedBack GetByUserName(string UserName)
        {
            throw new NotImplementedException();
        }

        public Contact GetContact()
        {
            throw new NotImplementedException();
        }

        public int Insert(FeedBack t)
        {
            return repository.Insert(t);
        }

 

        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FeedBack> Search(string searchString, int Page, int Pagesize)
        {
            throw new NotImplementedException();
        }

        public int Update(FeedBack t)
        {
            throw new NotImplementedException();
        }
    }
}
