using HRCRS_BACKEND.DTO;

namespace HRCRS_BACKEND.Model
{
    public interface Idemographic
    {
        public Task<DemographicInsertReturnType> DemographicInsert(DemographicType Newuser);
        public Task<bool> DemographicDelete(string id);
        public Task<DemographicUpdateReturnType> DemographicUpdate(DemographicType Newuser);
        public Task<IEnumerable<DemographicType>> DemographicReadAll();

        public Task<DemographicType> DemographicReadbyID(string id);
    }
}
