FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["EchoWeb/EchoWeb.csproj", "EchoWeb/"]
RUN dotnet restore "EchoWeb/EchoWeb.csproj"
COPY . .
WORKDIR "/src/EchoWeb"
RUN dotnet build "EchoWeb.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EchoWeb.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EchoWeb.dll"]