using Keycloak.NET.FluentAPI.Configure;
using Keycloak.NET.Manager.FluentAPI;
using Keycloak.NET.Manager.FluentAPI.Configurator.IdentityProviders;

namespace Keycloak.NET.FluentAPI
{
    internal class Configurator : IConfigurator
    {
        private readonly IRealmContext _context;

        public Configurator(IRealmContext context)
        {
            _context = context;
        }

        public IClients Clients => new Client(_context);
        public IClientScopes ClientScopes => new ClientScope(_context);
        public IRoles Roles => new Roles(_context);

        public IIdentityProviders IdentityProviders => new IdentityProviders(_context);
        public IRealmSettings RealmSettings => throw new System.NotImplementedException();
        public IUserFederation UserFederation => throw new System.NotImplementedException();
        public IAuthentication Authentication => throw new System.NotImplementedException();
    }
}