# ====== STAGE 1: Build ======
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Копируем всё, кроме того, что исключено в .dockerignore (.git, bin, obj и т.д.)
COPY . .

# Переходим в проект WebApp (точка входа приложения)
WORKDIR /src/Course.WebApp

# Восстанавливаем зависимости
RUN dotnet restore

# Собираем и публикуем в папку /app/publish
RUN dotnet publish -c Release -o /app/publish


# ====== STAGE 2: Runtime ======
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Создаём директории для базы данных и ключей защиты
RUN mkdir -p /app/Data /root/.aspnet/DataProtection-Keys

# Копируем опубликованное приложение из build stage
COPY --from=build /app/publish .

# Открываем порт и задаём адрес
ENV ASPNETCORE_URLS=http://+:8080

# Указываем путь к базе через переменную окружения (универсально)
ENV ConnectionStrings__Sqlite="Data Source=/app/Data/InventoryDb.db"

# Документируем порт
EXPOSE 8080

# Указываем точку входа
ENTRYPOINT ["dotnet", "Course.WebApp.dll"]
