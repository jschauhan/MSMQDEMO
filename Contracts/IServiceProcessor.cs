using System;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using BO;

namespace Contracts
{
    [ServiceContract()]
    public interface IServiceProcessor
    {
        [OperationContract(IsOneWay = true)]
        void SubmitMessage(MSMQMessage request);
    }
}
