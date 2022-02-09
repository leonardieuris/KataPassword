using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KataPassword5._05._0;

namespace KataPassword5._0
{
    public class SpecialCharValidator : AbstractValidator
    {
        public SpecialCharValidator(ResultValidation result):base(result)
        {

        }
        public override ResultValidation Validate(string input)
        {
            var result = input.Where(x => !char.IsLetterOrDigit(x));

            if (!result.Any())
            {
                _resultValidation.IsValid = false;
                _resultValidation.ErrorDescription.Add("password must contain at least one special character");

            }
            return Next == null ? _resultValidation : Next.Validate(input);
        }
    }
}
