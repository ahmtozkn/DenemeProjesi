using Deneme.Business.Managers;
using Deneme.Business.Services;
using Deneme.Data.Entities;
using Deneme.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Deneme.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
     
        public AuthController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,RoleManager<IdentityRole> roleManager )
        {
           _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

      

        public async Task<IActionResult> Login(UserVm userVm) 
        {
            var result=await _signInManager.PasswordSignInAsync(userVm.userName, userVm.Password,userVm.RememberMe,lockoutOnFailure: false); 

           if(result.Succeeded) 
            {
              return RedirectToAction("Index", "Card"); 
            
            }
            if (result.IsLockedOut)
            {
                // Kullanıcı hesabı kilitlendiği durum
                return View("Lockout");
            }
            else
            {
                // Başarısız giriş denemesi, hata nedenlerini model state'e ekleyin
              
                ViewBag.Error=result.ToString();
                return View(userVm);
            }


        }
        [HttpGet]

        public IActionResult Register() 
        {

            return View();
        
        }   

        [HttpPost]

        public async  Task<IActionResult> Register(RegisterVm registerVm, string returnUrl)
        {
            
            var user = new ApplicationUser()
            {
                Email=registerVm.Email,
                UserName=registerVm.UserName,


            };
            var result=await _userManager.CreateAsync(user,registerVm.Password);
            if (result.Succeeded)
            {
               

                return RedirectToAction("Login", "Auth");
            }
            
            return View(registerVm);
        }

        public async Task<IActionResult> Logout()
        {

            return View();
        }
    }
}
