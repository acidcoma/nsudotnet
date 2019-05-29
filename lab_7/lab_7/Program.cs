using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using VkNet;
using VkNet.AudioBypassService.Extensions;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace lab_7
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddAudioBypass(); 
            
            var api = new VkApi(services);
            
            api.Authorize(new ApiAuthParams
            {
                ApplicationId = 7001300,
                Login = "79138976357",
                Password = "wannasladko",
                Settings = Settings.All
            });
            //Console.WriteLine(api.Token);
            
            ProfileFields fields = ProfileFields.FirstName | ProfileFields.LastName | ProfileFields.Online;
            var friends = api.Friends.Get(new FriendsGetParams(){
                Order = FriendsOrder.Name,
                Fields = fields
            });
            Console.WriteLine("Friends: " + friends.TotalCount);
            foreach (var friend in friends)
            {
                Console.WriteLine(friend.FirstName + " " + friend.LastName + " " + friend.Online);
            }
            Console.WriteLine("Send message to...");
            var receive = Console.ReadLine();
            var result = receive.Split(" ");
   
            try
            {
                var person = friends.Where(x => x.FirstName == result[0] && x.LastName == result[1]);
          
                var randomId = new Random().Next(10000, 32000);
                Console.WriteLine("Message:");
                var message = Console.ReadLine();
                var msgid = api.Messages.Send(new MessagesSendParams
                {
                    UserId = person.First().Id,
                    RandomId = randomId,
                    Message = message
                });
                Console.WriteLine(msgid + " sent");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("write friend's name correctly");
            }
        }
    }
}