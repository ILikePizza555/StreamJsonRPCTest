using System;
using System.IO;
using System.Threading.Tasks;
using Nerdbank.Streams;

namespace SJRTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var (client, server) = SetUpClientAndServer();
            var result = await client.RequestDataFromServerRPC("username");
            Console.WriteLine($"Result: {result}");
        }

        static (Client, Server) SetUpClientAndServer()
        {
            (Stream, Stream) streams = FullDuplexStream.CreatePair();
            var client = new Client(streams.Item1);
            var server = new Server(streams.Item2);
            return (client, server);
        }
    }
}
