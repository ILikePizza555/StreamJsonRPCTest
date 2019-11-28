using System.Collections.Generic;
using System.Threading.Tasks;

namespace SJRTest
{
    interface IClientCallback
    {
        Task<Dictionary<string, string>> DictionaryDataCallback();
    }
}