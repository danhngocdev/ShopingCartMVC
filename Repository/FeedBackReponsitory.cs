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
    public class FeedBackReponsitory : IRepository<FeedBack>, IDisposable
    {
        private DBEntityContext context;
        public FeedBackReponsitory(DBEntityContext context)
        {
            this.context = context;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
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
            context.FeedBacks.Add(t);
            return context.SaveChanges();
        }

        public IEnumerable<FeedBack> ListProductHot()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FeedBack> ListProductNew()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FeedBack> ListProductSale()
        {
            throw new NotImplementedException();
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
