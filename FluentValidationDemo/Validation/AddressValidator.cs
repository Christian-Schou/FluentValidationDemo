using FluentValidation;
using FluentValidationDemo.Models;

namespace FluentValidationDemo.Validation
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            // Validate address is not longer than 60 chars as many APIs for carriers doesn't allow
            // longer address as they cannot be at the shipment label
            RuleFor(address => address.Street1).NotNull().NotEmpty().Length(1, 60);
            RuleFor(address => address.Street2).Length(1, 60);

            // Validate Country
            RuleFor(address => address.Country).NotNull().NotEmpty().WithMessage("Please add the destination country");

            // Validate City and ZIP
            RuleFor(address => address.PostalCode).NotNull().NotEmpty().WithMessage("Please add reciever postcode");
            RuleFor(address => address.PostalCode).Must(ValidPostCode).WithMessage("Postalcode is not valid");
            RuleFor(address => address.City).NotNull().NotEmpty().WithMessage("Please add the reciever city");
        }

        private bool ValidPostCode(string postalCode)
        {
            // Add logic for validating postalcode here...
            return true;
        }
    }
}
