using Microsoft.AspNetCore.Mvc;
using StreamPet.Models;

namespace StreamPet.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Logar(LoginModel loginModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    if(loginModel.Login == "adm@adm.com" && loginModel.Senha == "123")
                    {
                        return RedirectToAction("testelogin", "Home");
                    }
                    TempData["ErrorMessage"] = $"$Usuario e/ou senha invalidos!";

                }
                return View("Index");


            }

            catch (Exception Error)
            {
                throw;
            }
        }
    }
}
