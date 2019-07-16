using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    class CategoryReponsitory : IRepository<Category>, IDisposable
    {
       

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> Filter(Category t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Category t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> Search(string searchString)
        {
            throw new NotImplementedException();
        }

        public int Update(Category t)
        {
            throw new NotImplementedException();
        }
    }
}
