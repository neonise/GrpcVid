// See https://aka.ms/new-console-template for more information

using Dummy;
using Greet;
using Grpc.Core;

const string target = "127.0.0.1:50051";

Channel channel = new Channel(target, ChannelCredentials.Insecure);

channel.ConnectAsync().ContinueWith((task) =>
{
    if(task.Status == TaskStatus.RanToCompletion)
        Console.WriteLine("the client connected successfully!");
});

//var client = new DummyService.DummyServiceClient(channel);
var client = new GreetingService.GreetingServiceClient(channel);

var greeting = new Greeting
{
    FirstName = "Roli",
    LastName = "Moli"
};

var request = new GreetingRequest() {Greeting = greeting };
var response = client.Greet(request);

Console.WriteLine(response.Result);

channel.ShutdownAsync().Wait();
Console.ReadKey();
