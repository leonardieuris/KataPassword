using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPassword
{
    public class AtLeast2Numbers : AbstractValidator
    {

        public AtLeast2Numbers(ResultValidation resultValidation):base(resultValidation)
        {

        }
        public override ResultValidation Validate(string input)
        {
           
            var result = input.Where(x => char.IsDigit(x));

            if (result.Count() < 2)
            {
                _resultValidation.IsValid = false;
                _resultValidation.ErrorDescription.Add("The password must contain at least 2 numbers");
            
            }
            return Next == null ? _resultValidation : Next.Validate(input);
        }
    }
}
