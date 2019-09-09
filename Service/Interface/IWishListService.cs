﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
   public  interface IWishListService<T> where T : class
    {
        IEnumerable<T> GetAll();
        int Insert(T t);
        int Delete(int id);

    }
}