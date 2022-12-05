using HRCRS_BACKEND.DTO;
using RestEase;

namespace HRCRS_BACKEND.Model
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized, Body = BodySerializationMethod.Serialized)]
    public interface ILoginhttpService
    {
        [AllowAnyStatusCode]
        [Post]
        Task<Response<string>> Login([Body] UserInfo request);
    }
}
