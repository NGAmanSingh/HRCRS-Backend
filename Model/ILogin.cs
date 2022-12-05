using HRCRS_BACKEND.DTO;

namespace HRCRS_BACKEND.Model
{
    public interface ILogin
    {
        public Task<loginResponse> AuthenticateUser(UserInfo userinfo, string ADAuthUrl);
    }
}
