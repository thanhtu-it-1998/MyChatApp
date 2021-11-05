using Microsoft.AspNetCore.Mvc;
using MyChatApp.Applications.DAO;
using MyChatApp.Applications.Repository;
using MyChatApp.Commons;
using MyChatApp.Database.Entities;
using MyChatApp.Dto.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyChatApp.Controllers
{
    public class AccountController : Controller
    {
        public readonly IUserDAO dao;
        public AccountController(IUserDAO _dao)
        {
            dao = _dao;
        }
        public IActionResult Login() => View();


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var result = dao.Login(model.Username, Encryptor.MD5Hash(model.Password));
                if (result == 2)
                {
                    var user = dao.GetUserByUserName(model.Username);
                    var userSession = new UserLogin();
                    userSession.UserId = user.Id;
                    HttpContext.Session.Set<UserLogin>(ConstantCommons.USERSESSION, userSession);
                    return RedirectToAction("Index", "SocialNetwork");
                }
                else if (result == 0)
                {
                    TempData["Error"] = "Your account has been locked";
                }
                else if (result == 1)
                {
                    TempData["Error"] = "Your account is not correct";
                }
                else if (result == 3)
                {
                    TempData["Error"] = "Your account does not exist";
                }
                return View(model);
            }

            return View(model);

        }



        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                var resultUser = dao.CheckUsername(model.Username);
                if (resultUser)
                {
                    var resultTel = dao.CheckTel(model.Tel);
                    if (resultTel)
                    {
                        var user = new User();
                        user.Username = model.Username;
                        user.Tel = model.Tel;
                        user.Password = Encryptor.MD5Hash(model.Password);
                        user.RoleId = 2;
                        dao.Insert(user);
                        TempData["Success"] = " Account has been created, please login";
                        return RedirectToAction("Login", "Account");
                    }
                    else
                    {
                        TempData["Error"] = "This telphone already exists";
                    }
                }
                else
                {
                    TempData["Error"] = "This account already exists";
                }
                return View(model);
            }
            return View(model);
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove(ConstantCommons.USERSESSION);
            TempData["Success"] = "The account has been logged out of the system";
            return RedirectToAction("Login", "Account");
        }
    }
}
