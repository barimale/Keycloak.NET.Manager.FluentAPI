using Keycloak.NET.FluentAPI.Configure;
using Keycloak.NET.Manager.FluentAPI;
using NUnit.Framework;
using NUnit.Framework.Legacy;
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
            ClassicAssert.NotNull(context);
            ClassicAssert.NotNull(context.ConnectionSettings.ClientName);
            ClassicAssert.Null(context.ConnectionSettings.Password);
            ClassicAssert.Null(context.ConnectionSettings.Username);
            ClassicAssert.NotNull(context.ConnectionSettings.Token);
        }

        [Test]
        public void I_d_like_to_cannot_create_client_with_insufficient_priviligies()
        {
            ClassicAssert.ThrowsAsync<Flurl.Http.FlurlHttpException>(async () => CreateClientWithUnsofficientPriviligies());
        }

        private async Task CreateClientWithUnsofficientPriviligies()
        {
            //given
            var clients = context.Configurator.Clients;
            var clientId = "123s";

            //when
            var result = await clients.Create(clientId, Protocol.OPENID_CONNECT);

            //then
            ClassicAssert.Equals(result, true);

        }
    }
}