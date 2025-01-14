using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMVC.DAL.Model
{
    public class Department:ModelBase
    {

        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Code field is required.")]
        public string Code { get; set; }

        public DateTime DateOfCreation { get; set; }


        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();




    }
}
