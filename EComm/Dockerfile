FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app

# Copy source code and build the application 
COPY src/. .
RUN dotnet restore
RUN dotnet publish -c Release -o out 

# Define runtime command relative to build
ENTRYPOINT ["dotnet", "/app/EComm/out/EComm.dll"]
