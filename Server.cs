using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using StreamJsonRpc;

namespace SJRTest
{
    class Server
    {
        JsonRpc rpc;

        Server(Stream stream)
        {
            rpc = new JsonRpc(stream);
        }

        public async Task<string> RequestDataFromClientRPC(string key, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                Console.WriteLine("Entered RequestDataFromClientRPC");
                var result = await this.rpc.InvokeWithCancellationAsync<Dictionary<string, string>>(nameof(IClientCallback.DictionaryDataCallback), cancellationToken: ct).ConfigureAwait(false);
                return result[key];
            }
            catch (RemoteInvocationException e)
            {
                Console.Error.WriteLine($"RPC Exception: {e}");
                return string.Empty;
            }
        }
    }
}