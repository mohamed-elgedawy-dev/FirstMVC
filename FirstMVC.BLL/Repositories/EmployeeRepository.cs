using FirstMVC.BLL.Interfaces;
using FirstMVC.DAL.Data;
using FirstMVC.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMVC.BLL.Repositories
{
    class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {

        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {


        }

        public IQueryable<Employee> GetEmployeeByAddress(string address)
        => _dbContext.Employees.Where(d => d.Address.ToLower() == address.ToLower());

        public IQueryable<Employee> search(string name)

           => _dbContext.Employees.Where(d => d.Name.ToLower().Contains(name));



    }
}
