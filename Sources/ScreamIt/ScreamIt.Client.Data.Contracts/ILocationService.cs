using System.Threading.Tasks;

namespace ScreamIt.Client.Data.Contracts
{
    public interface ILocationService
    {
        Task InitializeLocationServiceAsync();
    }
}