using System;
using System.Security.Authentication;
using Client.Proxy;


namespace Client
{
    public class Program
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("Press enter to call service...");
            Console.ReadLine();
            var client = new ServiceProcessorClient();
            User user = new User();
            user.UserName = "san";
            user.Password = "sa";
            client.SubmitMessage(user);
            Console.ReadLine();
        }
    }
}
