﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Search(string searchString);
        IEnumerable<T> Filter(T t);
        int Insert(T t);
        int Update(T t);
        int Delete(int id);
        T GetById(int id);
        int Login(LoginModel model, bool isLoginAdmin = false);
       
    }
}
