# Picnic Platform

Picnic Platform is a platform where members of the system can create picnics and
invite their friends to them.

<pre>
You can reach the Technical Roadmap document by following <a href="Planning.md">this link</a>
</pre>

An overall architecture diagram is like below:

<img src="OverallArchitecture.png" width="600" />

This code example focuses only on the `picnic-service` microservice which is
responsible for querying and inserting objects related to the Picnic domain.

The Entity-relation diagram is like below:

<img src="ERDiagramForPicnic.png" width="600" />

You can do the below operations with the written application

- List all picnics
- Create a picnic
- Create a picnic invite
- List all invites to a picnic

## The Code Structure

This microservice model uses Clean Architecture principles which are inspired by
the
[Clean Architecture template of Jason Taylor](https://github.com/jasontaylordev/CleanArchitecture)

Although a PostgreSQL instance was used in the architectural design, MS SQL
Server is used in this code base to shorten coding time. Though on a
real implementation, I strongly think that an open-source database should be
used for this kind of product.

## Application Setup

### Prerequisites

This application runs on .NET 6 so .NET Runtime should be installed on your
computer to run the
application. You can download it from [here](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).

### DB Setup

We can easily setup a MS SQL Server on our local computers with the support of
Docker. If you don't have Docker on your desktop you can download
[here](https://www.docker.com/)

For downloading and creating an SQL Server Express edition with Docker, you can
execute the below command in your Terminal.

```shell
docker run --name picnic-sql -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=PicnicS@" -e "MSSQL_PID=Express" -p 1434:1433 -d mcr.microsoft.com/mssql/server:2019-latest
```

After the docker container is up and ready, we can run the below command to gain access container's bash.

```
docker exec -it picnic-sql /bin/sh
```

Then run the below command on the sh opened:
```
/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'PicnicS@'
```

This will bring up the MSSQL commandline to you. We can run the below script that would create the DB and the DB user.
```
CREATE DATABASE PicnicPlatform;
GO
Use PicnicPlatform;
GO

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'PicnicUser')
BEGIN
    CREATE USER PicnicUser FOR LOGIN PicnicUser
    EXEC sp_addrolemember N'db_owner', N'PicnicUser'
    EXEC master..sp_addsrvrolemember @loginame = N'PicnicUser', @rolename = N'sysadmin'
END;
GO
```

After then we can run the app with a connection to SQL Server.