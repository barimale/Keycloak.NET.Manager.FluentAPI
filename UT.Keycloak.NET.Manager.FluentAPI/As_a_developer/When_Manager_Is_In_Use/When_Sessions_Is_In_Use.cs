using Keycloak.NET.Manager.FluentAPI;
using NUnit.Framework;
using System.Threading.Tasks;
using UT.Keycloak.NET.FluentAPI;

namespace UT.Keycloak.NET.Manager.FluentAPI.As_a_developer.When_Manager_Is_In_Use
{
    public class When_Sessions_Is_In_Use
    {
        [SetUp]
        public void Setup()
        {
            //intentionally left blank
        }

        [Test]
        public async Task I_d_like_to_logout_all_sessions()
        {
            //given
            var context = RealmContext.Create()
               .WithCredentials(InputData.Username, InputData.Password)
               .Endpoint(InputData.Endpoint)
               .ToRealm(InputData.Realm)
               .ToClientName(InputData.ClientId, InputData.ClientSecret);

            //when
            var result = await context.Manager.Sessions.RealmSessions.LogoutAllAsync();

            //than
            Assert.IsTrue(result);
        }

        [Test]
        public async Task I_d_like_to_push_revocation()
        {
            //given
            var context = RealmContext.Create()
               .WithCredentials(InputData.Username, InputData.Password)
               .Endpoint(InputData.Endpoint)
               .ToRealm(InputData.Realm)
               .ToClientName(InputData.ClientId, InputData.ClientSecret);

            //when
            var result = await context.Manager.Sessions.Revocation.SetToNowAndPushAsync();

            //than
            Assert.NotNull(result);
        }
    }
}
