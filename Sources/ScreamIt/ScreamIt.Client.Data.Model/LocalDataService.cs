using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;
using ScreamIt.Client.Data.Contracts;

namespace ScreamIt.Client.Data.Model
{
    public class LocalDataService  : ILocalDataService
    {
        public Task<IEnumerable<Contact>> GetAllContacts()
        {
            return Task.Run(() =>
            {
                ContactStore contactStore = ContactManager.RequestStoreAsync().GetResults();

                //contactStore.GetContactListAsync()
                return new List<Contact>().AsEnumerable();
            });
        }
    }
}