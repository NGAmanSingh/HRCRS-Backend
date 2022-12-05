using HRCRS_BACKEND.DTO;
using Newtonsoft.Json;

namespace HRCRS_BACKEND.Model
{
    public class tokenGenerate:ItokenGenerate
    {
      

        public async Task<Token> GenerateToken(UserInfo userInfo)
        {
            //Generate random number between 1 to 2000
            Random rnd = new Random();
            int random = rnd.Next(1, 2000);

            // Generate time interval from random number
            TimeSpan interval = TimeSpan.FromMilliseconds(random);
            String timeStamp = interval.ToString();

            //Set the validity of the token 
            DateTime validity = DateTime.Now.AddMinutes(20);

            //Generate Token Key
            string tokenKey = userInfo.username + timeStamp;
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(tokenKey);
            string base64TokenKey = System.Convert.ToBase64String(plainTextBytes);


            Token tk = new Token() { tokenString = base64TokenKey, validity = validity };
            return tk;
        }
    }
}
