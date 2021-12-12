# Web devops Project - T4

## Used Technology
- Database: MySQL
- NuGet packages:
 - Microsoft.AspNetCore.Authentication.OpenIdConnect
 - Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
 - Microsoft.AspNetCore.Identity.EntityFrameworkCore (probably unused, to check)
 - Microsoft.AspNetCore.Identity.Identity.UI (probably unused, to check)
 - Microsoft.AspNetCore.EntityFrameworkCore.SqlServer (should only be used as fallback in case of problems with MySQL)
 - Microsoft.EntityFrameworkCore.Tools
 - Pomelo.EntityFrameworkCore.MySQL

## How to run
- The main branch should be using the Mysql (172.30.0.10:3306) connection string for both the webapp and the API. This connection string references the remote database hosted by the Ops team.
- Development branches should be using a local connection string, preferably Mysqllocal. Although MSSQLlocal will work aswell.
- If there are any issues starting the app: the cause will most likely be a change in the database model. It's a good idea to drop the local database and start the app again. This way the database is created anew with the updated model and initial data (locations, rooms, seats).

## Members
- Groupmember 1 : thomasboghaert - Boghaert - Thomas
- Groupmember 2 : YvesVanduynslager - Vanduynslager - Yves
- Groupmember 3 : LorenzBaeleOfficial - Baele - Lorenz
- Groupmember 4 : MaartenGoethals - Goethals - Maarten
- Groupmember 5 : ThomasDeNeve - De Neve - Thomas
- Groupmember 6 : CuyLil - Cuypers - Liliane
