using HRCRS_BACKEND.DTO;
using HRCRS_BACKEND.Model;
using Microsoft.AspNetCore.Mvc;

using System.Text;
using Newtonsoft.Json;

namespace HRCRS_BACKEND.Controllers
{
    
   
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        string ADAuthUrl =string.Empty;
        ILogin _login;
        public LoginController(IConfiguration configuration, ILogin login) // The IConfiguration interface is used to read Settings and Connection Strings from AppSettings.json file.
        {
            ADAuthUrl = configuration.GetValue<string>("ADAuthUrl");
            _login = login;
        }
        [HttpPost(Name = "Auth")]

        public async Task<loginResponse> Post([FromBody] UserInfo userInfo)
        {
            return await _login.AuthenticateUser(userInfo, ADAuthUrl);
        }
    }
}
