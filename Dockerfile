ARG VERSION=6.0

# Build
FROM mcr.microsoft.com/dotnet/sdk:$VERSION AS build
WORKDIR /src
COPY Tournament.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c release -o /app

# Run
FROM mcr.microsoft.com/dotnet/aspnet:$VERSION
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Tournament.dll"]
