# EFCoreDemoProject

Messing around with EFCore and PostgreSQL :P

Clone the repo installed the project dependencies setup your secret password and should be good to go

```bash
dotnet restore
dotnet user-secrets init
dotnet user-secrets set PostgresDbSettings:Password <insert-your-password-here>
docker-compose up
```

## pgadmin4

If you'd like to visually see the database you can connect with a database management tool of your choice, but in this project I am using pgadmin.
once docker is up and you start go to [http://localhost:5050/](http://localhost:5050/)
