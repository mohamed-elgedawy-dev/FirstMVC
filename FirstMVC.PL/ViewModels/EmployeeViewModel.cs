using FirstMVC.DAL.Model;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;

namespace FirstMVC.PL.ViewModels
{
    public class EmployeeViewModel:ModelBase
    {

        [Required(ErrorMessage ="Name is Required")]
        [MaxLength(50 , ErrorMessage ="max is 50")]
        [MinLength(5, ErrorMessage = "min is 5")]
        public string Name { get; set; }
        [Range(22,40 ,ErrorMessage ="from 22 to 40")]
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

        public string PhoneNumber { get; set; }

        public DateTime HiringDate { get; set; }

        public Gender Gender { get; set; }

        public EmpType EmpType { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } = false;

        public string ImageName { get; set; }

        public int? DepartmentId { get; set; }

        public Department? Department { get; set; }

        public IFormFile Image { get; set; }

    }
}
