using Keycloak.Net;
using Keycloak.NET.FluentAPI.Settings;
using System.Threading.Tasks;

namespace Keycloak.NET.FluentAPI.Base
{
    public abstract class BaseContext : IBaseContext
    {
        public IConnectionSettings ConnectionSettings { get; private set; } = new ConnectionSettings();

        public KeycloakClient Client { get; private set; }

        internal virtual async Task<BaseContext> Connect()
        {
            try
            {
                if(string.IsNullOrEmpty(ConnectionSettings.Token))
                {
                    Client = new KeycloakClient(
                    ConnectionSettings.Url,
                    ConnectionSettings.Username,
                    ConnectionSettings.Password);
                }
                else
                {
                    Client = new KeycloakClient(
                       ConnectionSettings.Url,
                       () => { return ConnectionSettings.Token; });
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            return this;
        }
    }
}
