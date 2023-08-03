using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalCore.Models;

namespace TraversalCore.Controllers
{
    [AllowAnonymous] //Hertürlü erişime açık olması için kimlik doğrulaması gerektirmeksizin herkese açık hale gelir.
    public class LoginController : Controller
    {
        //Identity, kullanıcı kimlik doğrulaması, roller ve
        //yetkilendirme gibi işlevleri sağlar.AppUser ve AppRole türleri,
        //uygulamanızın kullanıcıları ve rolleri için özelleştirilmiş sınıflardır.

        //UserManager classı: kullanıcıların yönetimini sağlar , kullanıcılarla ilgili işlemleri gerçekleştirmek için kullanılır.
        private readonly UserManager<AppUser> _userManager;

        //SignInManager classı: kullanıcıların oturum açma ve oturum kapatma gibi işlemlerini gerçekleştirmek için kullanılır.
        private readonly SignInManager<AppUser> _signInManager;

        //yapıcı metot
        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        #region Sign Up
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        //Asenkron metotlar, belirli bir işlemin tamamlanmasını beklemek yerine, arka planda çalışırken diğer işlemlere izin verir. Böylece, uygulama diğer işlemleri yaparken metot asenkron olarak çalışabilir.

        //"Task" ise, asenkron bir işlemin tamamlandığını temsil eden bir dönüş değeri türüdür. Task nesnesi, metot tamamlandığında veya sonuç döndüğünde tamamlanmış bir durumu temsil eder.

        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel p)
        {
            AppUser appuser = new AppUser()
            {
                Name = p.Name,
                Surname = p.Surname,
                Email = p.Mail,
                UserName = p.UserName
            };

            if (p.Password == p.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appuser, p.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(p);
        }
        #endregion

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.username, p.Password, false, true);

                //"await" ifadesi, _signInManager.PasswordSignInAsync metodunun tamamlanmasını bekler bu süre zarfında diğer işlemlerin gerçekleştirilmesine izin verir. 

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Profile", new { area = "Member" });
                }
            }
            else
            {
                return RedirectToAction("SıgnIn", "Login");
            }

            return View();
        }

    }
}
