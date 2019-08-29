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
    public class SliderService : IServices<Slider>
    {
        private IRepository<Slider> repository;
        public SliderService()
        {
            repository = new SliderReponsitory(new DBEntityContext());
        }
        
        public int Delete(int id)
        {
            return repository.Delete(id);
        }

        public IEnumerable<Slider> GetAll()
        {
            return repository.GetAll();
        }

        public Slider GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Slider GetByUserName(string UserName)
        {
            throw new NotImplementedException();
        }

        public Contact GetContact()
        {
            throw new NotImplementedException();
        }

        public int Insert(Slider t)
        {
            return repository.Insert(t);
        }

        public IEnumerable<Slider> ListProductHot()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Slider> ListProductNew()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Slider> ListProductSale()
        {
            throw new NotImplementedException();
        }

        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Slider> Search(string searchString)
        {
            throw new NotImplementedException();
        }

		public IEnumerable<Slider> Search(string searchString, int Page, int Pagesize)
		{
			throw new NotImplementedException();
		}

		public int Update(Slider t)
        {
            return repository.Update(t);
        }
    }
}
