using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using serverManagement2.Models;

namespace serverManagement2.StateStore
{
    public class SessionStorage
    {
        private readonly ProtectedSessionStorage protectedSessionStorage;

        public SessionStorage(ProtectedSessionStorage protectedSessionStorage)
        {
            this.protectedSessionStorage = protectedSessionStorage;
        }

        public async Task<Server?> GetServerAsync()
        {
            var result = await protectedSessionStorage.GetAsync<Server>("server");
            return result.Success ? result.Value : null;
        }

        public async Task SetServerAsync(Server? server)
        {
            await this.protectedSessionStorage.SetAsync("server", server);
        }
    }
}

