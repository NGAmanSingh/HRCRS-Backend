namespace HRCRS_BACKEND.DTO
{
    public class DemographicInsertReturnType
    {
       public bool Validation { get; set; }
       public bool Conflict { get; set; }
       public List<string>? Errors { get; set; }
       public DemographicType? DemographicObject { get; set; }
    }
}
