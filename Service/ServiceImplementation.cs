using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceModel.MsmqIntegration;

using BO;
using Contracts;
using System.IO;
using System.Text;

namespace Service
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, IncludeExceptionDetailInFaults = true, InstanceContextMode = InstanceContextMode.PerCall)]
    public class ServiceImplementation : IServiceProcessor
    {
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true, ReleaseInstanceMode = ReleaseInstanceMode.AfterCall)]
        public void SubmitMessage(MSMQMessage request)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(MSMQMessage));
            // Deserialize the data and read it from the instance.
            MemoryStream stream = new MemoryStream();
            ser.WriteObject(stream, request);

            var jsonString = Encoding.Default.GetString((stream.ToArray()));
            Console.WriteLine(jsonString);
            Console.WriteLine("Service call received : " + request);
            Console.WriteLine("press 1 to raise excepion; anything else to complete call...");
            var key = Console.ReadKey(true);
            
            Console.WriteLine(key.Key);
            if (key.Key == ConsoleKey.D1)
            {
                
                Console.WriteLine("User initiated rollback!");
                throw new Exception("Rollback due to exception");
            }
            Console.WriteLine("Commiting transactional receive!");
        }
    }
}
