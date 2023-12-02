
using DAL.Db.IdnetityEntity;
using DAL.DTOs.User;
using DAL.Services.Email;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Security.Claims;

namespace lighten.Controllers
{
    public class UserController1 : Controller
    {
        private readonly UserManager<user> _usermanager;
        private readonly SignInManager<user> _signInManager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly EmailService _emailService;
        public UserController1(UserManager<user>user, SignInManager<user> signInManager,RoleManager<IdentityRole> role)
        {
            _usermanager = user;
            _signInManager = signInManager;
            _rolemanager = role;
            _emailService = new EmailService();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(SignInDto dto) //signin user
        {
            if(!ModelState.IsValid)
            {
                return View(dto);
            }
            user newuser = new user()
            {
                UserName = dto.UserName,
                PhoneNumber = dto.Phone,
                Name = dto.Name,
                Email = dto.Email,
               

            };

            var result = _usermanager.CreateAsync(newuser, dto.Password).Result;

            if (result.Succeeded)
            {
                _usermanager.AddToRoleAsync(newuser, "member"); //Add Role
                return RedirectToAction("Index", "Home");
                //Claim newclaim=new Claim(ClaimTypes.Name, dto.Name);

                //var resultclaim=_usermanager.AddClaimAsync(newuser,newclaim).Result;

                //if (resultclaim.Succeeded)
                //{
                   
                //}


                //var token = _usermanager.GenerateEmailConfirmationTokenAsync(newuser).Result; //SendEmail

                //string CallBackUrl = Url.Action("ConfirmEmail", "UserController1", new {UserId=newuser.Id,Token=token},protocol:Request.Scheme);
                //string body = $"click me<br/><a href{CallBackUrl}>link</a>";

                //_emailService.Execute(newuser.Email, body, "Email Service Activity");


                
            }
            string message = "";
            foreach (var item in result.Errors.ToList())
            {
                message += item.Description + Environment.NewLine;
            }
            TempData["Message"] = message;


            return View(dto);

        }
        [HttpGet]  
        public IActionResult Login()//login user
        {
            return View() ;
        }
        [HttpPost]
        public IActionResult Login(LoginDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(Login(dto));
            }
            var user = _usermanager.FindByEmailAsync(dto.Email).Result;

            if (user == null)
            {
                return View(dto);
            }

            var result = _signInManager.PasswordSignInAsync(user, dto.Password, dto.IsPersistant, true).Result;

            if (result.Succeeded)
            {
                

                return RedirectToAction("Index", "Home");
            }
            


            return View(dto);
        }
        public IActionResult LogOut()//logout user
        {
            _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult DisplayEmail()
        {
            return View();
        }
        public IActionResult ConfirmEmail(string UserId,string token) //ConfirmEmail
        {
            if(UserId== null || token == null)
            {
                return BadRequest();
            }
            var user=_usermanager.FindByIdAsync(UserId).Result;

            var result=_usermanager.ConfirmEmailAsync(user, token).Result;

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

           

            return View();
        }
        public IActionResult ForgetPassword() //forget Password
        {
            return View();
        }
        [HttpPost]
        public IActionResult ForgetPassword(ForgetPasswordDto dto)
        {
            var user=_usermanager.FindByEmailAsync(dto.Email).Result;  

            if(user == null ||_usermanager.IsEmailConfirmedAsync(user).Result==false)
            {
               

                return View(dto);

            }

            var token = _usermanager.GeneratePasswordResetTokenAsync(user).Result;

            var CallBackUrl = Url.Action("RestPassword", "UserController1", new { UserId = user.Id, Token = token }, protocol: Request.Scheme);

            string body = $"Click On the link<a href={CallBackUrl}>link</a>";

            _emailService.Execute(user.Email, body, "RestPassword");


           


            return RedirectToAction("DisplayRestPassword", "UserController1");
        }

        public IActionResult DisplayRestPassword()
        {
            return View();
        }

        public IActionResult RestPassword(string UserId,string Token) //Rest Password
        {
            return View(new RestPasswordDto
            {
                UserId = UserId,
                Token = Token

            });
        }
        public IActionResult RestPassword(RestPasswordDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View("error");
            }

            var user=_usermanager.FindByIdAsync(dto.UserId).Result;

            if (user == null)
            {
                return View("error");
            }

            var result=_usermanager.ResetPasswordAsync(user,dto.Token,dto.Password).Result;
            if (result.Succeeded)
            {
                return View("change succeeded");
            }

            string message = "";
            foreach (var item in result.Errors.ToList())
            {
                message += item.Description + Environment.NewLine;
            }
            TempData["Message"] = message;

            return View("eror");
        }

    }
}
