using Keycloak.NET.Manager.FluentAPI;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.IO;
using System.Threading.Tasks;
using UT.Keycloak.NET.FluentAPI;

namespace UT.Keycloak.NET.Manager.FluentAPI.As_a_developer.When_Manager_Is_In_Use
{
    public class When_Import_Is_In_Use
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
               .ToClientName(InputData.ClientId);

            var realm = await context.Manager.Export.ExportAsync(true, true);

            //when
            var result = await context.Manager.Import.ImportAsync(realm);

            //then
            ClassicAssert.IsTrue(result);
        }

        [Test]
        public async Task I_d_like_to_import_realm_from_file()
        {
            //given
            var context = RealmContext.Create()
               .WithCredentials(InputData.Username, InputData.Password)
               .Endpoint(InputData.Endpoint)
               .ToRealm(InputData.Realm)
               .ToClientName(InputData.ClientId, InputData.ClientSecret);

            var inputFilePath = string.Concat(AppDomain.CurrentDomain.BaseDirectory, "realm-export.json");
            var inputFile = File.ReadAllBytes(inputFilePath);

            //when
            var result = await context.Manager.Import.ImportAsync(inputFile);

            //then
            ClassicAssert.IsTrue(result);
        }
    }
}
