using System;
using System.IO;
using Nerdbank.Streams;

namespace SJRTest
{
    class Program
    {
        static async void Main(string[] args)
        {
            var (client, server) = SetUpClientAndServer();
            var result = client.RequestDataFromServerRPC("username");
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
