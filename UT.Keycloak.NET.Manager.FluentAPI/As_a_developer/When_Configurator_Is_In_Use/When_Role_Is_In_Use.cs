using Keycloak.NET.FluentAPI;
using NUnit.Framework;
using System.Threading.Tasks;
using UT.Keycloak.NET.FluentAPI;

namespace UT.Keycloak.NET.Manager.FluentAPI.As_a_developer.When_Configurator_Is_In_Use
{
    public class When_Role_Is_In_Use
    {
        [SetUp]
        public void Setup()
        {
            //intentionally left blank
        }

        [Test]
        public async Task I_d_like_to_add_new_role_to_specific_client()
        {
            //given
            var context = RealmContext.Create()
                .WithCredentials(InputData.Username, InputData.Password)
                .Endpoint(InputData.Endpoint)
                .ToRealm(InputData.Realm)
                .ToClientName(InputData.ClientId);

            //when
            var result = await context.Configurator.Roles.AddRoleAsync("dummy");

            //than
            Assert.IsTrue(result);
        }
    }
}