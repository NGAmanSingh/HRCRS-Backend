using HRCRS_BACKEND.DTO;

namespace HRCRS_BACKEND.Model
{
    public interface IAuthrizedUser
    {
        public  Task<bool> AuthrizeUser(UserInfo userinfo);
    }
}
