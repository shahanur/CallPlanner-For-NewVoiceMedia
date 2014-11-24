#region

using CallPlanner.Core.Interfaces;
using CallPlanner.Core.Validator;

#endregion

namespace CallPlanner.Core.Factories
{
    public class ValidatorFactory : IValidatorFactory
    {
        public InteractionValidator GetValidator<T>() where T : InteractionValidator, new()
        {
            return new T();
        }
    }
}