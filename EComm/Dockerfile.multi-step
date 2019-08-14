FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app

# Copy source code and build the application 
COPY src/. .
RUN dotnet restore
RUN dotnet publish -c Release -o out 


# Build runtime container
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime

WORKDIR /app
COPY --from=build /app/EComm/out/. ./
ENTRYPOINT ["dotnet", "EComm.dll"]
