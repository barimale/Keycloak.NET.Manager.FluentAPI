# Keycloak.NET.Manager.FluentAPI
## 1. Context builder examples:

```
	var allRealmsContext = Context.Create()
		.WithCredentials(InputData.Username, InputData.Password)
		.Endpoint(InputData.Endpoint)
		.AllRealms();

	var specificRealmContext = RealmContext.Create()
        .WithCredentials(InputData.Username, InputData.Password)
        .Endpoint(InputData.Endpoint)
        .ToRealm(InputData.Realm)
        .ToClientName(InputData.ClientId);
```

## 2. Context capabilities: 
### Fluent API's schema is determined as a reflection of Keycloak Administration Console website.

### Example of the usage of logout method:

```
	context.Manager.Sessions.RealmSessions.LogoutAllAsync()
```