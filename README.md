# Ecommerce App using .NET 6 and Angular 13
eCommerce App using .NET 6 Web API with Entity Framework Core and SQL Server. Web UI built using Angular 13

# The project is a work in progress. There are currently 4 projects within the solution. 

JustSports.Core
JustSports.Infrastructure
JustSports.WebApi
JustSports.Web.UI

# Demo Links

Web UI
https://justsports.digitalaces.co.za/

Web Api (Swagger)
https://webapi.digitalaces.co.za/swagger/index.html

# Setup Instructions

# WebUI (Client)

This Web UI project was built using Angular 13. In order to install the required packages, you can cd into the following directory: JustSports.Web.UI and then run the install command (ie: npm install). See below:

![image](https://user-images.githubusercontent.com/82180135/174236808-9eaf710f-2784-44c1-96cd-32d615f8dcdc.png)

Once the packages have installed, run “ng serve --open”

# Web Api

If your environment is pointing to your local "dev" environment, you will need to ensure you are running the WebApi project. If you are using the "prod" environment, you should be pointing to the following url:

https://webapi.digitalaces.co.za/api/v1

See the following files for the configuration of these settings:

environment/environment.ts and 
environment/environment.prodt.ts

The Web Api [projects connects to a SQL database. To install the database locally, see the script file located in:

JustSports.WebApi/DBScripts

JustSportsCreate.sql


