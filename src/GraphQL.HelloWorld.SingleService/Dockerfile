FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5001
EXPOSE 5000

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY src/GraphQL.HelloWorld.SingleService/GraphQL.HelloWorld.SingleService.csproj src/GraphQL.HelloWorld.SingleService/
RUN dotnet restore src/GraphQL.HelloWorld.SingleService/GraphQL.HelloWorld.SingleService.csproj
COPY . .
WORKDIR /src/src/GraphQL.HelloWorld.SingleService
RUN dotnet build GraphQL.HelloWorld.SingleService.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish GraphQL.HelloWorld.SingleService.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GraphQL.HelloWorld.SingleService.dll"]
