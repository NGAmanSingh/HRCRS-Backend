using HRCRS_BACKEND.DTO;

namespace HRCRS_BACKEND.Model
{
    public interface ItokenGenerate
    {
       public Task<Token> GenerateToken(UserInfo userInfo);
    }
}
