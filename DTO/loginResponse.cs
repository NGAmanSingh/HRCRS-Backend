using HRCRS_BACKEND.Controllers;

namespace HRCRS_BACKEND.DTO
{
    public class loginResponse
    {
        public bool status { get; set; } = false;
        public Token ? code { get; set; }

    }
    public class Token { 
        public string tokenString { get; set; }
        public DateTime validity { get; set; }
    };
}
