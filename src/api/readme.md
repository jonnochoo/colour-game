# Choo Apps

## Setup PostgreSQL

```
docker run --name choo-app-postgres -e POSTGRES_DB=chooapp -e POSTGRES_USER=root -e POSTGRES_PASSWORD=password -v pgdata:/var/lib/postgresql/data -p 5432:5432 -d postgres
```

## EF

```
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
```

```
dotnet ef migrations add InitialCreate
dotnet ef database update
```