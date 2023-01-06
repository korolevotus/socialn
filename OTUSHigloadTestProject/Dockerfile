FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OTUSHigloadTestProject/OTUSHigloadTestProject.csproj", "OTUSHigloadTestProject/"]
RUN dotnet restore "OTUSHigloadTestProject/OTUSHigloadTestProject.csproj"
COPY . .
WORKDIR "/src/OTUSHigloadTestProject"
RUN dotnet build "OTUSHigloadTestProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OTUSHigloadTestProject.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OTUSHigloadTestProject.dll"]