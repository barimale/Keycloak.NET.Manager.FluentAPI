using Keycloak.NET.Manager.FluentAPI;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Linq;
using System.Threading.Tasks;
using UT.Keycloak.NET.FluentAPI;

namespace UT.Keycloak.NET.Manager.FluentAPI.As_a_developer.When_Configurator_Is_In_Use
{
    public class When_Role_Is_In_Use
    {
        private RealmContext context;

        [OneTimeSetUp]
        public void Setup()
        {
            context = RealmContext.Create()
                .WithCredentials(InputData.Username, InputData.Password)
                .Endpoint(InputData.Endpoint)
                .ToRealm(InputData.Realm)
                .ToClientName(InputData.ClientId, InputData.ClientSecret);
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            //context.Client.DeleteClientAsync(InputData.Realm, ClientName);
        }

        [Test]
        public async Task I_d_like_to_add_new_role_to_specific_client()
        {
            //given

            //when
            var result = await context.Configurator.Roles.AddRoleAsync(Guid.NewGuid().ToString("n"));

            //than
            ClassicAssert.IsTrue(result);
        }

        [Test]
        public async Task I_d_like_to_remove_role_from_specific_client()
        {
            //given
            var context = RealmContext.Create()
                .WithCredentials(InputData.Username, InputData.Password)
                .Endpoint(InputData.Endpoint)
                .ToRealm(InputData.Realm)
                .ToClientName(InputData.ClientId);

            var newName = Guid.NewGuid().ToString();
            await context.Configurator.Roles.AddRoleAsync(newName);

            //when
            var result = await context.Configurator.Roles.DeleteRoleAsync(newName);

            //than
            ClassicAssert.IsTrue(result);
        }

        [Test]
        public async Task I_d_like_to_get_role_by_Id()
        {
            //given
            var context = RealmContext.Create()
                .WithCredentials(InputData.Username, InputData.Password)
                .Endpoint(InputData.Endpoint)
                .ToRealm(InputData.Realm)
                .ToClientName(InputData.ClientId, InputData.ClientSecret);

            var allOfThem = await context.Configurator.Roles.AllAsync();
            var newOne = allOfThem.First();

            //when
            var result = context.Configurator.Roles.GetRoleById(newOne.Id);

            //than
            ClassicAssert.IsNotNull(result);
        }
    }
}