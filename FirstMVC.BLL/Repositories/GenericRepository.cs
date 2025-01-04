using FirstMVC.BLL.Interfaces;
using FirstMVC.DAL.Data;
using FirstMVC.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMVC.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase
    {
        private protected readonly ApplicationDbContext _dbContext;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }



        public int Add(T entity)
        {
            _dbContext.Add(entity);

            return _dbContext.SaveChanges();
        }



        public int Delete(T entity)
        {
            _dbContext.Remove(entity);

            return _dbContext.SaveChanges();
        }







        public int Update(T entity)
        {
            _dbContext.Update(entity);

            return _dbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
         => _dbContext.Set<T>().AsNoTracking().ToList();


        public T GetById(int id)
          => _dbContext.Find<T>(id);
    }
}
