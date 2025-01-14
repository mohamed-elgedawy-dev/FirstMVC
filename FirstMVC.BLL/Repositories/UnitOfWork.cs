using FirstMVC.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMVC.BLL.Repositories
{
    public class UnitOfWork : IunitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; set ; }
        public IDepartmentRepository DepartmentRepository { get ; set ; }

        public int Complete()
        {
            throw new NotImplementedException();
        }
    }
}
