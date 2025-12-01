# ============================
#       BUILD STAGE
# ============================
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY Adres.Procurement.Api/Adres.Procurement.Api.csproj Adres.Procurement.Api/
COPY Adres.Procurement.Application/Adres.Procurement.Application.csproj Adres.Procurement.Application/
COPY Adres.Procurement.Domain/Adres.Procurement.Domain.csproj Adres.Procurement.Domain/
COPY Adres.Procurement.Infrastructure/Adres.Procurement.Infrastructure.csproj Adres.Procurement.Infrastructure/
COPY *.slnx ./

RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o /app/publish


# ============================
#       RUNTIME STAGE
# ============================
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

ENV DB_CONNECTION_STRING=""

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "Adres.Procurement.Api.dll"]
