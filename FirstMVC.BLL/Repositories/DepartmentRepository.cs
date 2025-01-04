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
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {

        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<Department> search(string name)

            => _dbContext.DepartmentSet.Where(d => d.Name.ToLower().Contains(name));

    }
}
