using FluentValidation;

namespace HRCRS_BACKEND.DTO
{
    public class DemographicUpdateReturnType: AbstractValidator<DemographicType>
    {
        public bool Validation { get; set; }
        public bool DataUpdated { get; set; }
        public List<string> Errors { get; set; }
    }
}
