using FluentValidationDemo.Models;
using FluentValidationDemo.Validation;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpPost("add")]
        public IActionResult Add(Customer model)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }

            return StatusCode(StatusCodes.Status200OK, "Model is valid!");
        }

        [HttpPut("update")]
        public IActionResult Update(Customer model)
        {
            CustomerValidator customerValidator = new();
            var validatorResult = customerValidator.Validate(model);

            if (!validatorResult.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, validatorResult.Errors);
            }

            return StatusCode(StatusCodes.Status200OK, "Model is valid for update!");
        }
    }
}
