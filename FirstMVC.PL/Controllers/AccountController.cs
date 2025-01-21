using FirstMVC.DAL2.Model;
using FirstMVC.PL.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FirstMVC.PL.Controllers
{
    public class AccountController : Controller
    {
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly UserManager<ApplicationUser> _userManager;

		public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
			_signInManager = signInManager;
			_userManager = userManager;
		}

        #region Sign Up


        public IActionResult SignUp()
        {

            return View();



        }



        [HttpPost]
         
		public async Task< IActionResult> SignUp(SignUpViewModel model)
		{
            if (ModelState.IsValid) 
            { 
                var user= await _userManager.FindByNameAsync (model.UserName);

                if (user == null)
                {
                    user = new ApplicationUser
                    {
                        UserName = model.UserName,
                        Email = model.Email,
                        IsAgree = model.IsAgree,
                        FName = model.FirstName,
                        LName = model.LastName
                    };

                 var result=   await _userManager.CreateAsync(user,model.Password);

                    if (result.Succeeded)  return RedirectToAction(nameof(LogIn)); 

                    foreach( var error in result.Errors)  ModelState.AddModelError(string.Empty, error.Description); 

                }
                ModelState.AddModelError(string.Empty, "this user name is ");
            }



			return View(model);



		}







		#endregion




		#region Sign In

        public IActionResult LogIn()
        {


            return View(); 

        }
        [HttpPost]
		public async Task <IActionResult> LogIn(LogInViewModel model)
		{
            if (ModelState.IsValid) 
            {
                var user = await _userManager.FindByEmailAsync (model.Email);
                 if(user is not null)
                
                { 
                var flag = await _userManager.CheckPasswordAsync(user, model.Password);
                    if (flag)
                    {
                        var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

                        if (result.Succeeded)
                            return RedirectToAction(nameof(HomeController.Index),"Home");

                    }
                
                }

                ModelState.AddModelError(string.Empty, "Invalid log in");
            
            }

            return View(model);


		
		}




		#endregion



	}
}
