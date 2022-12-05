using HRCRS_BACKEND.DTO;

namespace HRCRS_BACKEND.Model
{
    public interface IPincode
    {
        public Task<Pincoderesponse> PincodeData(int pincode);
    }
}
