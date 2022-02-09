using KataPassword5._0;

namespace KataPassword5._05._0
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
