using HRCRS_BACKEND.DTO;
using Microsoft.OpenApi.Models;
using RestEase;
//using RestSharp;
using System.Text.Json;
//using RestClient = RestSharp.RestClient;

namespace HRCRS_BACKEND.Model
{
    public class LoginService : ILogin
    {
        IAuthrizedUser _AuthrizedUser;
        ItokenGenerate _tokenGenerate;
        public LoginService(IAuthrizedUser AuthrizedUser, ItokenGenerate tokenGenerate)
        {
            _AuthrizedUser = AuthrizedUser;
            _tokenGenerate = tokenGenerate;
        }
        public async Task<loginResponse> AuthenticateUser(UserInfo userinfo, string ADAuthUrl)
        {

            #region Using RestEase
            var service = RestClient.For<ILoginhttpService>(ADAuthUrl);
            var result = await service.Login(userinfo);
            var responsecode = result.ResponseMessage.StatusCode;

            

            loginResponse obj1 = new loginResponse();

            if (responsecode.ToString().ToLower() == "ok")  // Authenticate
            {
                bool authResponse =  await _AuthrizedUser.AuthrizeUser(userinfo);
               
                if (authResponse) // Authrize
                {
                    Token tk = await _tokenGenerate.GenerateToken(userinfo); // Token Generation
                    obj1.status = true;
                    obj1.code = tk;
                    return obj1;
                }
            }
                return obj1;

            #endregion

            //var client = new RestClient(ADAuthUrl);
            //var request = new RestRequest(ADAuthUrl);
            //request.Method = Method.Post;
            //var requestString = JsonSerializer.Serialize(userinfo);
            //request.AddHeader("Content-Type", "application/json");
            //var body = requestString;
            //request.AddParameter("application/json", body, ParameterType.RequestBody);
            //RestResponse response = client.Execute(request);
            //var responseCode = response.StatusCode;
            //if (responseCode.ToString() == "OK")
            //{
            //    return true;
            //}
            //return false;
        }
    }
}
