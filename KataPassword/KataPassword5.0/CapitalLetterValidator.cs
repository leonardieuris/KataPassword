using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KataPassword5._05._0;

namespace KataPassword5._0
{
    public class CapitalLetterValidator : AbstractValidator
    {
        public CapitalLetterValidator(ResultValidation resultValidation) : base(resultValidation)
        {

        }

        public override ResultValidation Validate(string input)
        {
            var result = input.Where(x => char.IsUpper(x));

            if (!result.Any())
            {
                _resultValidation.IsValid = false;
                _resultValidation.ErrorDescription.Add("password must contain at least one capital letter");

            }
            return Next == null ? _resultValidation : Next.Validate(input);
        }
    }
}
