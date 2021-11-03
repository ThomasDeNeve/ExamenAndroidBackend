# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY devops-project-web-t4/*.sln ./devops-project-web-t4/
COPY devops-project-web-t4/*.csproj ./devops-project-web-t4/
COPY devops-project-web-t4-API/*.csproj ./devops-project-web-t4-API/
COPY devops-project-web-t4-TEST/*.csproj ./devops-project-web-t4-TEST/

# RUN dotnet clean devops-project-web-t4.csproj
RUN dotnet restore devops-project-web-t4/devops-project-web-t4.csproj
RUN dotnet restore devops-project-web-t4-API/devops-project-web-t4-API.csproj
RUN dotnet restore devops-project-web-t4-TEST/devops-project-web-t4-TEST.csproj

# copy everything else and build app
COPY . .
#COPY devops-project-web-t4/. ./devops-project-web-t4/
#COPY devops-project-web-t4-API/. ./devops-project-web-t4-API/
# COPY devops-project-web-t4-TEST/. ./devops-project-web-t4-TEST/

WORKDIR /source/devops-project-web-t4/
RUN ls -al
RUN dotnet publish devops-project-web-t4.csproj -c release -o /app --no-restore

WORKDIR /source/devops-project-web-t4-API/
# RUN ls -al
RUN dotnet publish devops-project-web-t4-API.csproj -c release -o /app --no-restore

WORKDIR /source/devops-project-web-t4-TEST/
RUN ls -al
RUN dotnet publish devops-project-web-t4-TEST.csproj -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "devops-project-web-t4.dll"]
