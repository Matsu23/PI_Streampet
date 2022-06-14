using Microsoft.AspNetCore.Mvc;
using StreamPet.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using MySql.Data.MySqlClient;

namespace StreamPet.Controllers
{
    public class LoginController : Controller

        
    {

        private readonly DataContext _context;

        public LoginController(DataContext context)
        {
            _context = context;
        }

        
        public IActionResult Index()
        {
            return View();
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

                var query = logins.Where(x => x.Email == loginModel.Login && x.Senha == loginModel.Senha).ToListAsync();
                

                if (ModelState.IsValid)
                {
                    if(query.Result.Count > 0)
                    {
                        

         
                            return RedirectToAction("testelogin", "Home");

                        

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
