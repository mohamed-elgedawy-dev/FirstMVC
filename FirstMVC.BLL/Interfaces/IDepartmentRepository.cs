using FirstMVC.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMVC.BLL.Interfaces
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        public IQueryable<Department> search(string id);





    }
}
