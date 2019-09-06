using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IWishListReponsitory<T> where T : class
    {
        IEnumerable<T> GetAll();
        int Insert(T t);
        int Delete(int id);
       
    }
}
