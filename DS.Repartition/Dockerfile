FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 56870
EXPOSE 44314

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["DS.Repartition/DS.Repartition.csproj", "DS.Repartition/"]
RUN dotnet restore "DS.Repartition/DS.Repartition.csproj"
COPY . .
WORKDIR "/src/DS.Repartition"
RUN dotnet build "DS.Repartition.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DS.Repartition.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DS.Repartition.dll"]