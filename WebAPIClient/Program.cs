using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Net.Http;
using WebAPIClient.Configuration;
using WebAPIClient.Models; // If you need JSON handling

class Program
{
    static async Task Main(string[] args)
    {
        Settings settings = new Settings(){Ip = "127.0.0.1",Port= 5284, Controller = "Message" };
        
        // Replace with the base URL of your Web API project
        var apiBaseUrl = $"http://{settings.Ip}:{settings.Port}/";

        var serviceProvider = new ServiceCollection()
            .AddHttpClient()
            .BuildServiceProvider();

        var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
        var httpClient = httpClientFactory.CreateClient();
        httpClient.BaseAddress = new Uri(apiBaseUrl);
       
        var messageData = new MessageData { Message = "Hello from console app!" };

        // Send the message
        var content = new StringContent(JsonConvert.SerializeObject(messageData), System.Text.Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(settings.Controller, content);

        // Process the response
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Message sent successfully!");
        }
        else
        {
            Console.WriteLine("Error sending message. Status code: " + response.StatusCode);
        }
    }
}