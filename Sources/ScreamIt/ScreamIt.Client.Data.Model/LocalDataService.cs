using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;
using ScreamIt.Client.Data.Contracts;

namespace ScreamIt.Client.Data.Model
{
    public class LocalDataService : ILocalDataService
    {
        public Task<IEnumerable<Contact>> GetAllContacts()
        {
            throw new NotImplementedException();
        }
    }
}
