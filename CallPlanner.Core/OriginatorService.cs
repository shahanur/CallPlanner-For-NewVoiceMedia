#region

using System;
using System.Linq;
using CallPlanner.Core.Entities;
using CallPlanner.Core.Exceptions;
using CallPlanner.Core.Interfaces;

#endregion

namespace CallPlanner.Core
{
    public class OriginatorService : IOriginatorService
    {
        private readonly IOriginatorDataProvider _originatorDataProvider;
        private readonly IPrinter _printer;

        public OriginatorService(IOriginatorDataProvider originatorDataProvider, IPrinter printer)
        {
            _originatorDataProvider = originatorDataProvider;
            _printer = printer;
        }

        public OriginatorResponse GetOriginatorSpecificData(Interaction interaction)
        {
            var response = new OriginatorResponse
            {
                ResponseNumber = -1,
                ResponseType = ResponseTypeEnumerator.ResponseType.Other
            };
            try
            {
                var originator = _originatorDataProvider.Provide(interaction);
                if (null == originator)
                    throw new TimeoutException("Request timed out.");
                var responseNumber = ResponseNumberGenerator();
                response.ResponseNumber = responseNumber;
                response.ResponseType = GetResponseType(responseNumber);
                response.InteractionType = interaction.InteractionType;
                response.ResponseMessage = responseNumber.ToString();
            }
            catch (InvalidInteractionException exception)
            {
                response.ResponseMessage = exception.Message;
            }
            catch (TimeoutException exception)
            {
                response.ResponseMessage = exception.Message;
            }

            _printer.Write(string.Format("Invoke function with {0}, response is {1}", interaction.Input,
                response.ResponseMessage));
            return response;
        }

        private static ResponseTypeEnumerator.ResponseType GetResponseType(int responseNumber)
        {
            int result;
            Math.DivRem(responseNumber, 2, out result);
            return result == 0 ? ResponseTypeEnumerator.ResponseType.Even : ResponseTypeEnumerator.ResponseType.Odd;
        }

        private static int ResponseNumberGenerator()
        {
            var random = new Random();
            var randomNumbers = Enumerable.Range(1, 4);
            return randomNumbers.OrderBy(x => random.Next()).Take(2).First();
        }
    }
}