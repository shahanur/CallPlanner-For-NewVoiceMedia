#region

using CallPlanner.Core.Validator;

#endregion

namespace CallPlanner.Core.Interfaces
{
    public interface IValidatorFactory
    {
        InteractionValidator GetValidator<T>() where T : InteractionValidator, new();
    }
}