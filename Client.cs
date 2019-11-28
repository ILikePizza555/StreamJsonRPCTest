using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using StreamJsonRpc;

namespace SJRTest
{
    class Client : IClientCallback
    {
        private JsonRpc rpc;

        public Client(Stream stream)
        {
            rpc = JsonRpc.Attach(stream, this);
        }

        public async Task<string> RequestDataFromServerRPC(string key, CancellationToken ct = default(CancellationToken))
        {
            Console.WriteLine("Entered RequestDataFromServerRPC");
            
            var arguments = new List<string>();
            arguments.Add(key);
            return await this.rpc.InvokeWithCancellationAsync<string>(nameof(Server.RequestDataFromClientRPC), arguments, ct);
        }

        public async Task<Dictionary<string, string>> DictionaryDataCallback()
        {
            Console.WriteLine("Entered DictionaryDataCallback");

            var d = new Dictionary<string, string>();
            d.Add("username", "Izzy");
            d.Add("password", "hunter2");
            d.Add("heart", "❤️");
            return d;
        }
    }
}