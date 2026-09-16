FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
RUN apt update && apt install -y nodejs
COPY ["src/Demo.web/Demo.web.csproj","Demo.web/"]
COPY ["src/Demo.Domain/Demo.Domain.csproj","Demo.Domain/"]
COPY ["src/Demo.Application/Demo.Application.csproj","Demo.Application/"]
COPY ["src/Demo.Infrastructure/Demo.Infrastructure.csproj","Demo.Infrastructure/"]
RUN dotnet restore "Demo.web/Demo.web.csproj"

COPY ./src/ .
WORKDIR /src/Demo.web
RUN dotnet build "Demo.web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Demo.web.csproj" -c Release -o /app

FROM build AS final
WORKDIR /app
COPY --from=publish /app .
EXPOSE 80
ENTRYPOINT [ "dotnet" ,"Demo.web.dll" ]