using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;

namespace ScreamIt.Client.Data.Contracts
{
    public interface ILocalDataService
    {

        Task<IEnumerable<Contact>> GetAllContacts();

    }

    public interface IContact
    {

    }
}