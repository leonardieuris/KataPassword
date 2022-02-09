using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace KataPassword
{
    public class Container
    {
        public static T GetService<T>()
        => CreateHostBuilder().Services.GetService<T>();


        private static IHost CreateHostBuilder() =>
            Host
                .CreateDefaultBuilder()
                .ConfigureServices((_, services) =>
                    services
                        .AddSingleton<CheckerPassword>()
                        .AddSingleton<IValidator>(_ =>
                        {
                            var resultValidation = new ResultValidation { ErrorDescription = new List<string>(), IsValid = true };
                            var validator = new AtLeast8CharValidator(resultValidation);
                            var validatorNumbers = new AtLeast2Numbers(resultValidation);
                            var capitalLetterValidator = new CapitalLetterValidator(resultValidation);
                            validatorNumbers.SetNext(capitalLetterValidator);
                            var specialCharValidator = new SpecialCharValidator(resultValidation);
                            capitalLetterValidator.SetNext(specialCharValidator);
                            validator.SetNext(validatorNumbers);
                            return validator;
                        })
                ).Build();

    }
}
