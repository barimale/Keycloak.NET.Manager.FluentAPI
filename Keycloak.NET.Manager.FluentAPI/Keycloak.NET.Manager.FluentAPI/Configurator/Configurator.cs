using Keycloak.NET.FluentAPI.Configure;

namespace Keycloak.NET.Manager.FluentAPI.Configurator
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
        public IAuthentication Authentication => new Authentication(_context);
    }
}