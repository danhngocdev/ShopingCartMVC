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
            throw new NotImplementedException();
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
            context.Users.Add(new User()
            {
                UserName = user.UserName,
                Password = user.Password,
                CreatedDate = DateTime.Now,
                EditedDate = DateTime.Now,
                FullName = user.FullName,
                Phone = user.Phone,
                Email = user.Email,
                Address = user.Address,
                Status = user.Status
            });
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

        public IEnumerable<User> Search(string searchString)
        {
            throw new NotImplementedException();
        }

        public int Update(User t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> ListProductHot()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> ListProductSale()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> ListProductNew()
        {
            throw new NotImplementedException();
        }
    }
}
