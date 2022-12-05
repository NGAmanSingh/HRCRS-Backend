using FluentValidation.Results;
using HRCRS_BACKEND.DTO;
using HRCRS_BACKEND.Model;
using HRCRS_BACKEND.Validators;
using Microsoft.AspNetCore.Mvc;

namespace HRCRS_BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemographicController : Controller
    {
        Idemographic _demographic;
        public DemographicController(Idemographic demographic)
        {
            _demographic = demographic;
        }

        [HttpPost]
        public async Task<DemographicInsertReturnType> Post([FromBody] DemographicType demo)
        {
                return await _demographic.DemographicInsert(demo);
        }

        [HttpDelete]
        public async Task<bool> Delete([FromBody] string id)
        {
            return await _demographic.DemographicDelete(id);
        }

        [HttpPut]
        public async Task<DemographicUpdateReturnType> Update([FromBody] DemographicType demo)
        {
            return await _demographic.DemographicUpdate(demo);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<DemographicType> ReadById( string id)
        {
            return await _demographic.DemographicReadbyID(id);
        }

        [HttpGet]
        public async Task<IEnumerable<DemographicType>> ReadAll()
        {
            return await _demographic.DemographicReadAll();
        }



    }
}
