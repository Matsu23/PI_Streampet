using Microsoft.AspNetCore.Mvc;
using StreamPet.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using MySql.Data.MySqlClient;

namespace StreamPet.Controllers
{
    public class LoginController : Controller

        
    {

        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Logar(LoginModel loginModel)
        {
            MySqlConnection mySqlCon = new MySqlConnection("server=localhost;initial catalog=StreamPetDB;uid=root;pwd=senha123");
            await mySqlCon.OpenAsync();
            MySqlCommand mySqlComd = mySqlCon.CreateCommand();
            mySqlComd.CommandText = $"SELECT * FROM usuarios WHERE Email = '{loginModel.Login}' AND Senha = '{loginModel.Senha}'  ";
            MySqlDataReader reader = mySqlComd.ExecuteReader();

            try
            {

                if (ModelState.IsValid)
                {
                    if(mySqlComd.ExecuteNonQuery() > 0)
                    {
                        while(await reader.ReadAsync())
                        {
                            return RedirectToAction("testelogin", "Home");

                        }

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
