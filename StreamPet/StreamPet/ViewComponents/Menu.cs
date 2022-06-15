using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StreamPet.Models;
using System.Threading.Tasks;

namespace StreamPet.ViewComponents
{
    public class Menu:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string userSession = HttpContext.Session.GetString("UserActiveSession");
            if (string.IsNullOrEmpty(userSession)) return null;

            LoginModel user = JsonConvert.DeserializeObject<LoginModel>(userSession);

            return View(user);
        }
    }
}
