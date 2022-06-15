using Microsoft.AspNetCore.Mvc;
using StreamPet.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using MySql.Data.MySqlClient;
using StreamPet.Helper;

namespace StreamPet.Controllers
{
    public class LoginController : Controller

        
    {

        private readonly DataContext _context;
        private readonly Helper.ISession _sessao;


        public LoginController(DataContext context, Helper.ISession sessao)
        {
            _context = context;
            _sessao = sessao;
        }

        
        public IActionResult Index()
        {
            if(_sessao.getSession() != null) return RedirectToAction("Index","Home");
            return View();
        }

        public IActionResult Logout()
        {
            _sessao.RemoveUserSession();
            return RedirectToAction("Index", "Login");
        }

        public DataContext Get_context()
        {
            return _context;
        }

        [HttpPost]

        public async Task<IActionResult> Logar(LoginModel loginModel)
        {
            var logins =  _context.Usuarios;


            try {

                var query = logins.Where(x => x.Name == loginModel.Login && x.Senha == loginModel.Senha).ToListAsync();
                

                if (ModelState.IsValid)
                {
                    if(query.Result.Count > 0)
                    {


                        _sessao.CreateUserSession(loginModel);
                            return RedirectToAction("Index", "Home");

                        

                        //return RedirectToAction("testelogin", "Home");
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
