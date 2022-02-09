using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPassword
{
    public abstract class AbstractValidator : IValidator
    {
        protected IValidator? Next;
        protected ResultValidation _resultValidation;

        public AbstractValidator(ResultValidation resultValidation)
        {
            _resultValidation = resultValidation;
        }

        public IValidator SetNext(IValidator validator)
        {
            Next = validator;
            return validator;
        }

        public abstract ResultValidation Validate(string input);
    }
}
