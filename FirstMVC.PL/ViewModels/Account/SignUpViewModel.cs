using System.ComponentModel.DataAnnotations;

namespace FirstMVC.PL.ViewModels.Account
{
	public class SignUpViewModel
	{
		[Required(ErrorMessage = "User Name is required")]

		public string UserName { get; set; }

        [Required(ErrorMessage ="Email is required")]
		[EmailAddress(ErrorMessage ="Invalid Email")]
        public string Email { get; set; }

		[Required(ErrorMessage ="password is required")]
		[MinLength(5,ErrorMessage ="min length 5")]
		[DataType(DataType.Password)]
        public string Password { get; set; }
		[Required]
		[Display(Name ="First Name")]
        public  string FirstName { get; set; }
		[Required]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }


		[Required(ErrorMessage = "Confirm password is required")]
		[Compare(nameof(Password) ,ErrorMessage =" Confirm  password does not match ")]
		
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }


        public bool IsAgree { get; set; }

    }
}
