# ProductMicroservice

![alt text](https://github.com/ShriLingam23/ProductMicroservice/blob/master/Assets/Microservice%20Using%20ASP.NET%20Core.png)


### Entity Framework Core Migrations

Migrations allow us to provide code to change the database from one version to another.
Inorder to this install Microsoft.EntityFrameworkCore.Tools.

1. Inorder to create a Migration File execute following command in the Package Manager 
```
> Add-Migration <AnyMeaningfulName>
```

2.Later to apply migrations to the current database where we point in appsetting.json
```
> Update-Database
```

