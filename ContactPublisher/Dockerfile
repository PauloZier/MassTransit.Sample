FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /publisher

COPY . ./

RUN dotnet restore

RUN dotnet build

RUN dotnet publish ./ContactPublisher/ContactPublisher.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /publisher

COPY --from=build /publisher/out /publisher/build

WORKDIR /publisher/build

ENTRYPOINT ["dotnet", "/publisher/build/ContactPublisher.dll"]