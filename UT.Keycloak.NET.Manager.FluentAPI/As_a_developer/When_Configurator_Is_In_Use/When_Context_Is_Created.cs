using Keycloak.NET.FluentAPI.Configure;
using Keycloak.NET.Manager.FluentAPI;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using UT.Keycloak.NET.FluentAPI;

namespace UT.Keycloak.NET.Manager.FluentAPI.As_a_developer.When_Configurator_Is_In_Use
{
    public class When_Context_Is_Created
    {
        private IRealmContext context;

        [SetUp]
        public void Setup()
        {
            context = RealmContext.Create()
                .WithCredentials(InputData.Username, InputData.Password)
                .Endpoint(InputData.Endpoint)
                .ToRealm(InputData.Realm)
                .ToClientName(InputData.ClientId);
        }

        [Test]
        public void I_d_like_to_create_context_with_token()
        {
            //given

            //when
            var context = RealmContext.Create()
                    .WithToken(Guid.NewGuid().ToString())
                    .Endpoint(InputData.Endpoint)
                    .ToRealm(InputData.Realm)
                    .ToClientName(InputData.ClientId);

            //than
            Assert.NotNull(context);
            Assert.NotNull(context.ConnectionSettings.ClientName);
            Assert.Null(context.ConnectionSettings.Password);
            Assert.Null(context.ConnectionSettings.Username);
            Assert.NotNull(context.ConnectionSettings.Token);
        }

        [Test]
        public void I_d_like_to_cannot_create_client_with_insufficient_priviligies()
        {
            Assert.ThrowsAsync<Flurl.Http.FlurlHttpException>(async () => CreateClientWithUnsofficientPriviligies());
        }

        private async Task CreateClientWithUnsofficientPriviligies()
        {
            //given
            var clients = context.Configurator.Clients;
            var clientId = "123s";

            //when
            await clients.Create(clientId, Protocol.OPENID_CONNECT);

            //than
        }
    }
}