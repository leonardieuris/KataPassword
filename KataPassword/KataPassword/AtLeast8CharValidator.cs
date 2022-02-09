using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPassword
{
    public class AtLeast8CharValidator : AbstractValidator
    {
        public AtLeast8CharValidator(ResultValidation resultValidation) : base(resultValidation)
        {

        }
        public override ResultValidation Validate(string input)
        {
            if (input.Length < 8)
            {
                _resultValidation.IsValid = false;
                _resultValidation.ErrorDescription.Add("Password must be at least 8 characters");
            }
               
            return  Next == null ? _resultValidation: Next.Validate(input);
        }
    }
}
