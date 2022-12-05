using FluentValidation;
using HRCRS_BACKEND.DTO;
using HRCRS_BACKEND.Model;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace HRCRS_BACKEND.Validators
{
    public class DemographicValidation : AbstractValidator<DemographicType>
    {
        [Obsolete]
        public DemographicValidation()
        {
            RuleFor(p => p.ForeName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("First Name cannot be empty")
                .Length(2, 30).WithMessage("Lenght of Fisrt name is Invalid")
                .Matches("^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$");


            RuleFor(p => p.SurName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Last Name cannot be empty")
                .Length(2, 30).WithMessage("Lenght of Last name is Invalid")
                .Matches("^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$");


            RuleFor(p=>p.Pincode)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().NotEmpty().WithMessage("Pincode cannot be null or empty")
                .Must(BeAValidPostcode).WithMessage("Please specify a valid postcode");

            RuleFor(p => p.PhoneNumber)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().NotEmpty().WithMessage("Phone number cannot be empty or null")
                .Length(10).WithMessage("PhoneNumber must of 10 digit")
                .Must(BeAValidPhoneNumber).WithMessage("Enter Valid phonenumber Format");

            RuleFor(p => p.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Email cannot be null or Empty")
                .EmailAddress()
                .Length(5, 30).WithMessage("Enter Email of valid Lenght");

            //RuleFor(p => p.DateofBirth)
            //.Must(BeAValidAge).WithMessage("Invalid {PropertyName}");

            //RuleFor(p => p.IdentificationNumber)
            //    .Cascade(CascadeMode.StopOnFirstFailure)
            //    .NotEmpty().WithMessage("IdentificationNumber cannot be null or Empty")
            //    .Length(10).WithMessage("Enter IdentificationNumber of valid Lenght")
            //    .Must(BeAValidIdNumber);

        }

        private bool BeAValidPostcode(int Pincode)
        {
            Regex pinregex = new Regex("^[1-9][0-9]{5}$");
            return pinregex.IsMatch(Pincode.ToString());
        }

        private bool BeAValidPhoneNumber(string PhoneNumber)
        {
            Regex phoneRex = new Regex(@"^[6-9]\d{9}$");
            return phoneRex.IsMatch(PhoneNumber.ToString());
        }

        //protected bool BeAValidAge(DateTime date)
        //{
        //    int currentYear = DateTime.Now.Year;
        //    int dobYear = date.Year;

        //    if ((currentYear-dobYear)>=18 && dobYear > (currentYear - 120))
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        //private bool BeAValidIdNumber(string IdentificationNumber)
        //{
        //    Regex idrex = new Regex("([a-z]){5}([0-9]){4}([a-z]){1}$");
        //    if (idrex.IsMatch(IdentificationNumber.ToString()) && IdentificationNumber[3] == 'P')
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

    }
}
