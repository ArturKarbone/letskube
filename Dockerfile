FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o output

# build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-focal
WORKDIR /app
COPY --from=build-env /app/output .
ENTRYPOINT ["dotnet", "LetsKube.dll"]