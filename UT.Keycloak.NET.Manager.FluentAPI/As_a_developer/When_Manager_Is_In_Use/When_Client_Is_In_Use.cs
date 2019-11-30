using Keycloak.NET.FluentAPI;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using UT.Keycloak.NET.FluentAPI;

namespace UT.Keycloak.NET.Manager.FluentAPI.As_a_developer.When_Manager_Is_In_Use
{
    public class When_Client_Is_In_Use
    {
        [SetUp]
        public void Setup()
        {
            //intentionally left blank
        }

        [Test]
        public async Task I_d_like_to_have_role_names_of_used_client()
        {
            //given
            var context = RealmContext.Create()
               .WithCredentials(InputData.Username, InputData.Password)
               .Endpoint(InputData.Endpoint)
               .ToRealm(InputData.Realm)
               .ToClientName(InputData.ClientId, InputData.ClientSecret);

            //when
            var result = await context.Configurator.Clients.GetDefaultClientRolesNamesAsync();
            
            //than
            Assert.NotNull(result);
            Assert.Greater(result.ToList().Count, 0);
        }
    }
}
