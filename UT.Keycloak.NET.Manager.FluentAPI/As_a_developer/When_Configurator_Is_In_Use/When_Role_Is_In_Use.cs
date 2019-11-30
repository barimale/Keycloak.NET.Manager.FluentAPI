﻿using Keycloak.NET.FluentAPI;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using UT.Keycloak.NET.FluentAPI;

namespace UT.Keycloak.NET.Manager.FluentAPI.As_a_developer.When_Configurator_Is_In_Use
{
    public class When_Role_Is_In_Use
    {
        private RealmContext context;
        private string ClientName = Guid.NewGuid().ToString();

        [OneTimeSetUp]
        public void Setup()
        {
            context = RealmContext.Create()
                .WithCredentials(InputData.Username, InputData.Password)
                .Endpoint(InputData.Endpoint)
                .ToRealm(InputData.Realm)
                .ToClientName(InputData.ClientId);

            context.Client.CreateClientAsync(InputData.Realm, new global::Keycloak.Net.Models.Clients.Client()
            {
                ClientId = ClientName,
                Protocol = "openId-connect"
            });

            //Add user to specific client
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            //intentionally left blank DELETE NEW CLIENT
            context.Client.DeleteClientAsync(InputData.Realm, context.ClientId);
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

        public async Task I_d_like_to_add_remove_role_from_specific_client()
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
            Assert.IsTrue(result);
        }
    }
}