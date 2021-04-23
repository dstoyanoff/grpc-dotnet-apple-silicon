using System;
using System.Threading.Tasks;
using grpc_dotnet;
using Grpc.Net.Client;

namespace client
{
  class Program
  {
    static async Task Main(string[] args)
    {
      var channel = GrpcChannel.ForAddress("http://127.0.0.1:5000");
      var client = new Greeter.GreeterClient(channel);

      var reply = await client.SayHelloAsync(new HelloRequest
      {
        Name = "gRPC!"
      });

      Console.WriteLine(reply.Message);
    }
  }
}
