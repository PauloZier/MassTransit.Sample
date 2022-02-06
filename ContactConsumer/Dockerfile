FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /consumer

COPY . ./

RUN dotnet restore

RUN dotnet build

RUN dotnet publish ./ContactConsumer/ContactConsumer.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /consumer

COPY --from=build /consumer/out /consumer/build

WORKDIR /consumer/build

ENTRYPOINT ["dotnet", "/consumer/build/ContactConsumer.dll"]