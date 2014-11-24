#region

using System.Collections.Generic;
using System.Linq;
using CallPlanner.Core.Entities;
using CallPlanner.Core.Exceptions;
using CallPlanner.Core.Interfaces;
using CallPlanner.Core.Validator;

#endregion

namespace CallPlanner.Core.Repositories
{
    public class InmemoryRepository : IRepository
    {
        private readonly IValidatorFactory _validatorFactory;
        private IList<Originator> _originators;

        public InmemoryRepository(IValidatorFactory validatorFactory)
        {
            _validatorFactory = validatorFactory;
            LoadOriginator();
        }

        public IEnumerable<Originator> GetOriginators()
        {
            return _originators;
        }

        public Originator GetOriginatorByEmail(string email)
        {
            var isValid = _validatorFactory.GetValidator<EmailValidator>().Validate(email);
            if (!isValid)
                throw new InvalidInteractionException();
            return _originators.SingleOrDefault(o => o.Email.ToLower().Equals(email.ToLower()));
        }

        public Originator GetOriginatorByPhoneNumber(string phoneNumber)
        {
            var isValid = _validatorFactory.GetValidator<PhoneNumberValidator>().Validate(phoneNumber);
            if (!isValid)
                throw new InvalidInteractionException();
            return _originators.SingleOrDefault(o => o.PhoneNumber.ToLower().Equals(phoneNumber.ToLower()));
        }

        private void LoadOriginator()
        {
            _originators = new[]
            {
                new Originator {Name = "Bob", Email = "bob@test.com", PhoneNumber = "1234"},
                new Originator {Name = "John", Email = "john@test.com", PhoneNumber = "5678"},
                new Originator {Name = "Osden", Email = "osden@test.com", PhoneNumber = "1237"},
                new Originator {Name = "Simon", Email = "simon@test.com", PhoneNumber = "6734"},
                new Originator {Name = "Alice", Email = "alice@test.com", PhoneNumber = "9111"}
            };
        }
    }
}