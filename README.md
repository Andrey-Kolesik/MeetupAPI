# MeetupAPI

## Setup

- MSSQL has been used as database
- You can change connection string from *appsettings.json* within *MeetupAPI*
- Apply database migrations to create the tables.

## Authentication

- Non auth endpoints requires JWT token to be provided otherwise 401 response will be returned
- Go https://localhost:5443/connect/token to get the JWT token then add it to the header while sending a request
- You can disable authentication for endpoints by removing ```Authorize``` attribute from the particular action

## Layers

- MeetupAPI - Presentation Layer is type of *.Net Core Web API project*.
- Business_Logic_Layer - Business Logic Layer responsible for data exchange between DAL and Presentation Layer.
  - It has Services, AutoMapperProfiles and Constants in it
- Data_Access_Layer - Data Access Layer responsible for interacting database. *Generic repositories* have been used.
  - Database context, repositories and database entity models are located in this class lib
- IdentityServer - ASP.NET Core Identity with IdentityServer
- IoC - library of classes with extension methods
