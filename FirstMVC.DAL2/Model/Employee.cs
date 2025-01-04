using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FirstMVC.DAL.Model
{

    public enum Gender
    {
        [EnumMember(Value = "Male")]
        Male = 1,


        [EnumMember(Value = "Female")]
        Female = 2

    }
    public enum EmpType
    {

        FullTime = 1, PartTime = 2
    }


    public class Employee:ModelBase
    {



        [Required]
        [MaxLength(50, ErrorMessage = "max length = 50")]
        [MinLength(50, ErrorMessage = "min length =50")]
        public string Name { get; set; }

        [Range(22, 30)]
        public int? Age { get; set; }

        [Required]
        public string Address { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Display(Name = "is active")]

        public bool IsActive { get; set; }


        [EmailAddress]
        public string Email { get; set; }


        [Phone]
        [Display(Name = " phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Hiring Date")]
        public DateTime HiringDate { get; set; }

        public Gender Gender { get; set; }

        public EmpType EmpType { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } = false;

        public int? DepartmentId { get; set; }
      





    }
}
