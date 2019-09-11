﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IListProduct<T> where T : class
    {
        IEnumerable<T> ListProductHot();
        IEnumerable<T> ListProductSale();
        IEnumerable<T> ListProductNew();
        IEnumerable<T> ListProductGetByCategory(int id,int pageIndex,int pageSize);
    }
}