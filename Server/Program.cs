// See https://aka.ms/new-console-template for more information
using Greet;
using Grpc.Core;
using Server;

const int Port = 50051;
Grpc.Core.Server server = null;

try
{
    server = new Grpc.Core.Server
    {
        Services = { GreetingService.BindService(new GreetingServceImpl()) },
        Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
    };

    server.Start();
    Console.WriteLine("the server is listening ont the port : " + Port);
    Console.ReadKey();
}
catch (Exception ex)
{
    Console.WriteLine("the server failed at start : " + ex.Message);
    throw;
}
finally
{
    if (server != null) server.ShutdownAsync().Wait();
}
