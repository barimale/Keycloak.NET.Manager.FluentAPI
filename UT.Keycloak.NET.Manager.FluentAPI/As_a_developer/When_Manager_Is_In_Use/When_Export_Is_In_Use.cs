using Keycloak.NET.Manager.FluentAPI;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Threading.Tasks;
using UT.Keycloak.NET.FluentAPI;

namespace UT.Keycloak.NET.Manager.FluentAPI.As_a_developer.When_Manager_Is_In_Use
{
    public class When_Export_Is_In_Use
    {
        [SetUp]
        public void Setup()
        {
            //intentionally left blank
        }

        [Test]
        public async Task I_d_like_to_import_realm()
        {
            //given
            var context = RealmContext.Create()
               .WithCredentials(InputData.Username, InputData.Password)
               .Endpoint(InputData.Endpoint)
               .ToRealm(InputData.Realm)
               .ToClientName(InputData.ClientId, InputData.ClientSecret);

            var realm = await context.Manager.Export.ExportAsync(true, true);

            //when
            var result = await context.Manager.Import.ImportAsync(realm);

            //then
            ClassicAssert.IsTrue(result);
        }

        [Test]
        public async Task I_d_like_to_export_realm()
        {
            //given
            var context = RealmContext.Create()
               .WithCredentials(InputData.Username, InputData.Password)
               .Endpoint(InputData.Endpoint)
               .ToRealm(InputData.Realm)
               .ToClientName(InputData.ClientId, InputData.ClientSecret);

            //when
            var result = await context.Manager.Export.ExportAsync(true, true);

            //then
            ClassicAssert.NotNull(result);
        }

        [Test]
        public async Task I_d_like_to_export_realm_as_byte_array()
        {
            //given
            var context = RealmContext.Create()
               .WithCredentials(InputData.Username, InputData.Password)
               .Endpoint(InputData.Endpoint)
               .ToRealm(InputData.Realm)
               .ToClientName(InputData.ClientId, InputData.ClientSecret);

            //when
            var result = await context.Manager.Export.ExportToByteArrayAsync(true, true);

            //then
            ClassicAssert.NotNull(result);
        }
    }
}
