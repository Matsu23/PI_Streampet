using StreamPet.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace StreamPet.Helper
{
    public class Session : ISession
    {

        private readonly IHttpContextAccessor _HttpContext;

      

        public Session(IHttpContextAccessor HttpContext)
        {
            _HttpContext = HttpContext;
        }
        public void CreateUserSession(LoginModel user)
        {
            string SessionValue = JsonConvert.SerializeObject(user);
            _HttpContext.HttpContext.Session.SetString("UserActiveSession", SessionValue);
        }

        public Usuario getSession()
        {
            string SessionValue = _HttpContext.HttpContext.Session.GetString("UserActiveSession");
            if (string.IsNullOrEmpty(SessionValue)) return null;
            return JsonConvert.DeserializeObject<Usuario>(SessionValue);
        }

        public void RemoveUserSession()
        {
            _HttpContext.HttpContext.Session.Remove("UserActiveSession");
        }
    }
}
