﻿using DAL;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Repository
{
    public class UserReponsitory : IRepository<User>, IDisposable
    {
        private DBEntityContext context;
        public UserReponsitory(DBEntityContext context)
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

       

        public IEnumerable<User> GetAll()
        {
	        return context.Users.ToList();
        }

        public User GetById(int id)
        {
	        return context.Users.Find(id);
        }

        public User GetByUserName(string UserName)
        {
            return context.Users.Where(s => s.UserName == UserName).SingleOrDefault();
        }

        public int Insert(User user)
        {
            user.Role = context.Roles.Where(s => s.RoleId == user.RoleId).SingleOrDefault();
            context.Users.Add(user);
            return context.SaveChanges();

        }

        

        public bool Login(string username, string password)
        {
            var res = context.Users.Count(s => s.UserName == username && s.Password == password);
            if (res>0)
            {

                return true;
            }
            else
            {
                return false;
            }

        }

		public IEnumerable<User> Search(string searchString, int Page, int Pagesize)
		{
			var model = context.Users.ToList();
			if (!string.IsNullOrEmpty(searchString))
			{
				model = model.Where(x => x.FullName.Contains(searchString)).ToList();
			}
			return model.OrderByDescending(x => x.CreatedDate).ToPagedList(Page, Pagesize);
		}

		public int Update(User t)
		{
			var currentItem = context.Users.Find(t.UserId);
			if (currentItem != null)
			{
				currentItem.RoleId = t.RoleId;
				currentItem.Password = t.Password;
				currentItem.EditedDate=DateTime.Now;
				currentItem.Address = t.Address;
				currentItem.Email = t.Email;
				currentItem.Phone = t.Phone;
				currentItem.Status = t.Status;
				currentItem.UserName = t.UserName;
			}
			context.Entry(currentItem).State = System.Data.Entity.EntityState.Modified;
		return	context.SaveChanges();
        }

       
        public Contact GetContact()
        {
            throw new NotImplementedException();
        }
    }
}
