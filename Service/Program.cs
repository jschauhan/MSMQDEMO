using System;
using System.Messaging;
using System.ServiceModel;

namespace Service
{
    public class Program
    {
        public const String QueueName = @".\private$\myQueue";

        public static void Main(String[] args)
        {
            Console.WriteLine("Press enter to start service...");
            Console.ReadLine();

            // Create the transacted MSMQ queue if necessary.
            if (!MessageQueue.Exists(QueueName))
            {
                Console.WriteLine("Queue does not exist. Creating transactional queue.");
                MessageQueue.Create(QueueName, true);
            }
            else
            {
                Console.WriteLine("Queue exists.");
            }

            using (ServiceHost serviceHost = new ServiceHost(typeof(ServiceImplementation)))
            {
                serviceHost.Open();

                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                serviceHost.Close();
            }
        }
    }
}
