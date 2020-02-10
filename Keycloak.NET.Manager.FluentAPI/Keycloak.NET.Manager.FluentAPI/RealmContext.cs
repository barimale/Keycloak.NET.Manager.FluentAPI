using Keycloak.Net.Models.Users;
using Keycloak.NET.FluentAPI;
using Keycloak.NET.FluentAPI.Base;
using Keycloak.NET.FluentAPI.Builder;
using Keycloak.NET.FluentAPI.Configure;
using Keycloak.NET.FluentAPI.Manage;
using System.Linq;

namespace Keycloak.NET.Manager.FluentAPI
{
    public sealed class RealmContext : BaseContext, IRealmContext
    {
        private RealmContext()
            : base()
        {
            //intentionally left blank
        }

        public IManager Manager => new NET.FluentAPI.Manage.Manager(this);
        public IConfigurator Configurator => new Configurator(this);

        private User userDetails;
        public User UserDetails
        {
            get
            {
                if (userDetails == null)
                {
                    var users = Client.GetUsersAsync(ConnectionSettings.Realm).GetAwaiter().GetResult();
                    userDetails = users.FirstOrDefault(p => p.UserName == ConnectionSettings.Username);
                }

                return userDetails;
            }
            private set
            {
                if (value != userDetails)
                {
                    userDetails = value;
                }
            }
        }

        private string clientId;

        public string ClientId
        { 
            get
            {
                if(clientId == null)
                {
                    var clients = Client.GetClientsAsync(ConnectionSettings.Realm).GetAwaiter().GetResult();
                    clientId = clients.FirstOrDefault(p => p.ClientId == ConnectionSettings.ClientName)?.Id;
                }

                return clientId;
            }
            private set
            {
                if(value != clientId)
                {
                    clientId = value;
                }
            }
        }

        public static ILoginAs Create()
        {
            return new ContextFluentBuilder(new RealmContext());
        }
    }
}
