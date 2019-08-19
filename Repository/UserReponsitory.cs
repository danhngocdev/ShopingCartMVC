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

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Filter(User t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(User t)
        {
            throw new NotImplementedException();
        }

        public int Login(LoginModel model, bool isLoginAdmin = false)
        {
            var result = context.Users.SingleOrDefault(u => u.UserName == model.UserName);
            var res = context.Roles.Where(x => x.RoleId == result.RoleId);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    //if (result.RoleId == CommonConstants.Admin_Role || result.RoleId == CommonConstants.Manager_Role)
                    if (res != null)
                    {
                        if (result.Password == Encryptor.MD5Hash(model.Password))
                        {
                            return 1;
                        }
                        else
                        {
                            return -2;
                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
                else
                {
                    if (result.Password == model.Password)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }

        }

        public IEnumerable<User> Search(string searchString)
        {
            throw new NotImplementedException();
        }

        public int Update(User t)
        {
            throw new NotImplementedException();
        }
    }
}
