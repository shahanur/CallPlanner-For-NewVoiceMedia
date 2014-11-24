#region

using System.Collections.Generic;
using CallPlanner.Core.Entities;

#endregion

namespace CallPlanner.Core.Interfaces
{
    public interface IRepository
    {
        IEnumerable<Originator> GetOriginators();
        Originator GetOriginatorByEmail(string email);
        Originator GetOriginatorByPhoneNumber(string phoneNumber);
    }
}