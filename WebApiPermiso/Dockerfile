FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
#COPY ["./WebApiPermiso/WebApiPermiso.csproj", ""]
COPY . ./
WORKDIR WebApiPermiso/
RUN dotnet restore "WebApiPermiso.csproj"
#WORKDIR "/src/."
RUN dotnet build "WebApiPermiso.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "WebApiPermiso.csproj" -c Release -o /app/publish
FROM  mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS final
WORKDIR /app
EXPOSE 44368
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApiPermiso.dll"]
