#region

using System.Linq;

#endregion

namespace CallPlanner.Core.Validator
{
    public class PhoneNumberValidator : InteractionValidator
    {
        public override bool Validate(string input)
        {
            return !string.IsNullOrWhiteSpace(input) &&
                   (input.Length == 4 && !input.ToCharArray().Any(digit => !char.IsDigit(digit)));
        }
    }
}