﻿using Keycloak.NET.Manager.FluentAPI;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using UT.Keycloak.NET.FluentAPI;

namespace UT.Keycloak.NET.Manager.FluentAPI.As_a_developer.When_Builder_Is_In_Use
{
    public class When_RealmContext_Is_In_Use
    {
        [SetUp]
        public void Setup()
        {
            //intentionally left blank
        }

        [Test]
        public void I_d_Like_have_content_correctly_created()
        {
            //given

            //when
            var content = RealmContext.Create()
                .WithCredentials(InputData.Username, InputData.Password)
                .Endpoint(InputData.Endpoint)
                .ToRealm(InputData.Realm)
                .ToClientName(InputData.ClientId);

            //then
            ClassicAssert.NotNull(content);
        }

        [Test]
        public void I_d_like_to_have_access_to_submodules()
        {
            //given
            var content = RealmContext.Create()
                .WithCredentials(InputData.Username, InputData.Password)
                .Endpoint(InputData.Endpoint)
                .ToRealm(InputData.Realm)
                .ToClientName(InputData.ClientId);

            //when
            var configuration = content.Configurator;
            var manager = content.Manager;
            var groups = content.Manager.Groups;
            var clients = content.Configurator.Clients;
            var clientScopes = content.Configurator.ClientScopes;
            var identityProviders = content.Configurator.IdentityProviders;

            //then
            ClassicAssert.NotNull(configuration);
            ClassicAssert.NotNull(manager);
            ClassicAssert.NotNull(groups);
            ClassicAssert.NotNull(clients);
            ClassicAssert.NotNull(clientScopes);
            ClassicAssert.NotNull(identityProviders);
        }
    }
}
