using Keycloak.Net.Models.Users;
using Keycloak.NET.FluentAPI;
using Keycloak.NET.FluentAPI.Base;
using Keycloak.NET.FluentAPI.Builder;
using Keycloak.NET.FluentAPI.Configure;
using Keycloak.NET.FluentAPI.Manage;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        public User UserDetails { get; private set; }

        public string ClientId { get; private set; }

        internal override async Task<BaseContext> Connect()
        {
            try
            {
                await base.Connect();

                var users = await Client.GetUsersAsync(ConnectionSettings.Realm);
                var clients = await Client.GetClientsAsync(ConnectionSettings.Realm);

                ClientId = clients.FirstOrDefault(p => p.ClientId == ConnectionSettings.ClientName)?.Id;
                UserDetails = users.FirstOrDefault(p => p.UserName == ConnectionSettings.Username);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (ClientId == null)
                    throw new ArgumentNullException("ClientId");
                if (UserDetails == null)
                    throw new ArgumentNullException("UserDetails");
            }

            return this;
        }

        public static ILoginAs Create()
        {
            return new ContextFluentBuilder(new RealmContext());
        }
    }
}
