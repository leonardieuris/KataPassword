using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPassword
{
    public class CheckerPassword
    {
        private IValidator _validator;

        public CheckerPassword(IValidator validator)
        {
            _validator = validator;
        }

        public ResultValidation Validate(string input) => _validator.Validate(input);

    }
}
