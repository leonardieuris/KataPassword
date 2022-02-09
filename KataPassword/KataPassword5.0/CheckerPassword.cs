using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPassword5._0
{
    public class CheckerPassword
    {
        private IValidator validator;

        public CheckerPassword()
        {
            var resultValidation = new ResultValidation { ErrorDescription = new List<string>(), IsValid = true };
            validator = new AtLeast8CharValidator(resultValidation);
            var validatorNumbers = new AtLeast2Numbers(resultValidation);
            var capitalLetterValidator = new CapitalLetterValidator(resultValidation);
            validatorNumbers.SetNext(capitalLetterValidator);
            var specialCharValidator = new SpecialCharValidator(resultValidation);
            capitalLetterValidator.SetNext(specialCharValidator);
            validator.SetNext(validatorNumbers);
        }

        public ResultValidation Validate(string input) => validator.Validate(input);

    }
}
