FROM mcr.microsoft.com/dotnet/core/aspnet:2.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build
WORKDIR /src
COPY ["Assembly-CSharp.csproj", "./"]
RUN dotnet restore "./Assembly-CSharp.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Assembly-CSharp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Assembly-CSharp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Assembly-CSharp.dll"]
