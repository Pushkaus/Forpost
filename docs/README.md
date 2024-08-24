# Forpost
#### Запуск всех сервисов в докере
```shell
docker-compose up --build
```
#### Остановить и удалить все контейнеры
```shell
docker-compose down 
```
#### "Мужицкий" перезапуск
```shell
docker-compose down; docker-compose up --build
```
# Миграции
Миграции делаются при помощи скриптов в проекте `Store.Migrations`
```csharp
Для миграции данных создаём постую миграцию (без модификации схемы) и в методы Up и Down
добавляем sql-скрипты. Прямой и обратный. ОБЯЗАТЕЛЬНО!
```