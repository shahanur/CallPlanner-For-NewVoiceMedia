#region

using CallPlanner.Core.Entities;
using CallPlanner.Core.Interfaces;

#endregion

namespace CallPlanner.Core
{
    public class OriginatorDataProvider : IOriginatorDataProvider
    {
        private readonly IRepository _repository;

        public OriginatorDataProvider(IRepository repository)
        {
            _repository = repository;
        }

        public Originator Provide(Interaction interaction)
        {
            return interaction.InteractionType.Equals(CpEnumerators.InteractionType.Email)
                ? _repository.GetOriginatorByEmail(interaction.Input)
                : _repository.GetOriginatorByPhoneNumber(interaction.Input);
        }
    }
}