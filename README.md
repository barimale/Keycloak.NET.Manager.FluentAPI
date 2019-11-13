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
### Fluent API's schema is determined as a reflection of the Keycloak Administration Console website, for instance:
```
	context.Manager
	.Sessions
	.RealmSessions
	.LogoutAllAsync()
```
