using Keycloak.NET.FluentAPI.Base;
using Keycloak.NET.FluentAPI.Builder;
using Keycloak.NET.FluentAPI.Realms;

namespace Keycloak.NET.Manager.FluentAPI
{
    public sealed class Context : BaseContext
    {
        private Context()
            : base()
        {
            //intentionally left blank
        }

        public NET.FluentAPI.Realms.IRealm Realm => new Realm(this);

        public static ILoginAs Create()
        {
            return new ContextFluentBuilder(new Context());
        }
    }
}
