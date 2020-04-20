using Microsoft.Azure.Documents.Client;
using System.Threading.Tasks;

namespace CosmosDBDemo.DataAccess.Utility
{

    public interface ICosmosConnection
    {
        Task<DocumentClient> InitializeAsync(string collectionId);
    }
}
