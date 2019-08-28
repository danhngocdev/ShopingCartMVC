﻿using DAL;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MenuReponsitory : IRepository<Menu>, IDisposable
    {
        private DBEntityContext context;
        public MenuReponsitory(DBEntityContext context)
        {
            this.context = context;
        }
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

      

        public IEnumerable<Menu> GetAll()
        {
            return context.Menus.ToList();
        }

        public Menu GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Menu GetByUserName(string UserName)
        {
            throw new NotImplementedException();
        }

        public int Insert(Menu t)
        {
            throw new NotImplementedException();
        }

        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Menu> Search(string searchString)
        {
            throw new NotImplementedException();
        }

        public int Update(Menu t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Menu> ListProductHot()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Menu> ListProductSale()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Menu> ListProductNew()
        {
            throw new NotImplementedException();
        }
    }
}
