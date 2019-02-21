FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["EchoWebV2.csproj", "EchoWebV2/"]
RUN dotnet restore "EchoWebV2/EchoWebV2.csproj"
WORKDIR "/src/EchoWebV2"
COPY . .
RUN dotnet build "EchoWebV2.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EchoWebV2.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EchoWebV2.dll"]