using HRCRS_BACKEND.DTO;
using HRCRS_BACKEND.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace HRCRS_BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PincodeController : Controller
    {
        IPincode _pincode;

        public PincodeController(IPincode pincode)
        {
            _pincode = pincode;
        }


        [HttpGet]
        public async Task<Pincoderesponse> getPincode([FromBody] int pincode)
        {
            return await _pincode.PincodeData(pincode);
        }

    }
}
