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
    public class SliderReponsitory : IRepository<Slider>, IDisposable
    {
        private DBEntityContext context;
        public SliderReponsitory(DBEntityContext context)
        {
            this.context = context;
        }
        public int Delete(int id)
        {
            var item = context.Sliders.Where(s => s.ID == id).SingleOrDefault();
            if (item.Status == false)
            {
                context.Sliders.Remove(item);
                context.SaveChanges();
            }
            return 0;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Slider> GetAll()
        {
            return context.Sliders.Where(x => x.Status == true).OrderByDescending(x => x.Created).Take(3).ToList();
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
            t.Created = DateTime.Now;
            context.Sliders.Add(t);
            return context.SaveChanges();
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
            t.ModifileDate = DateTime.Now;
            context.Entry(t).State = System.Data.Entity.EntityState.Modified;
            return context.SaveChanges();

        }
    }
}
