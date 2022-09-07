

using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace LaboBadgeServer.Data.Services
{
    public class Storage
    {
        private readonly ProtectedBrowserStorage _protectedBrowserStorage;
        public Storage(ProtectedBrowserStorage protectedBrowserStorage)
        {
            this._protectedBrowserStorage = protectedBrowserStorage;
        }

        public  async Task SetStorage()
        {
            var p = await _protectedBrowserStorage.GetAsync<string>("nick ");
        }


    }
}
