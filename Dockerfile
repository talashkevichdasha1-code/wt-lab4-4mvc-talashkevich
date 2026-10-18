
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["wt-lab4-4mvc-talashkevich.csproj", "./"]
RUN dotnet restore "wt-lab4-4mvc-talashkevich.csproj"

COPY . .
RUN dotnet publish "wt-lab4-4mvc-talashkevich.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

ENTRYPOINT ["dotnet", "wt-lab4-4mvc-talashkevich.dll"]
