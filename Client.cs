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

        Client(Stream stream)
        {
            rpc = new JsonRpc(stream);
        }

        public async Task<string> RequestDataDromServerRPC(string key, CancellationToken ct = default(CancellationToken))
        {
            var arguments = new List<string>();
            arguments.Add(key);
            return await this.rpc.InvokeWithCancellationAsync<string>(nameof(Server.RequestDataFromClientRPC), arguments, ct);
        }

        public async Task<Dictionary<string, string>> DictionaryDataCallback()
        {
            var d = new Dictionary<string, string>();
            d.Add("username", "Izzy");
            d.Add("password", "hunter2");
            d.Add("heart", "❤️");
            return d;
        }
    }
}