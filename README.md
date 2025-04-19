# Keycloak.NET.Manager.FluentAPI
## Keycloak 6.x
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
### Fluent API's schema is determined as a reflection of the Keycloak Administration Console website, for instance:
```
	var result = await allRealmsContext
		.Manager
		.Sessions
		.RealmSessions
		.LogoutAllAsync()
```
