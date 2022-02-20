using FluentValidation;
using FluentValidationDemo.Models;

namespace FluentValidationDemo.Validation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            // Check name is not null, empty and is between 1 and 250 characters
            RuleFor(customer => customer.FirstName).NotNull().NotEmpty().Length(1,250);
            RuleFor(customer => customer.LastName).NotNull().NotEmpty().Length(1, 250);

            // Validate Phone with a custom error message
            RuleFor(customer => customer.Phone).NotEmpty().WithMessage("Please add a phone number");

            // Validate Age for submitted customer has to be between 21 and 100 years old
            RuleFor(customer => customer.Age).InclusiveBetween(21, 100);

            // Validate the address (its a complex property)
            RuleFor(customer => customer.Address).InjectValidator();
        }
    }
}
