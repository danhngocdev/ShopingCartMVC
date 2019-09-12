using DAL;
using Model;
using Repository;
using Repository.Interface;
using Service.Interface;
using System.Collections.Generic;

namespace Service
{
    public class WishListService : IWishListService<WishList>
    {
        private IWishListReponsitory<WishList> repository;
        public WishListService()
        {
            repository = new WishListReponsitory(new DBEntityContext());
        }


        public int Delete(WishList item)
        {
	        return repository.Delete(item);
        }

        public IEnumerable<WishList> GetById(int id)
        {
	        return repository.GetById(id);
        }

        public IEnumerable<WishList> GetAll()
        {
            return repository.GetAll();
        }

        public int Insert(WishList t)
        {
            return repository.Insert(t);
        }
    }
}
