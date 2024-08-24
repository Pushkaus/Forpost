## Соглашения по кодированию
* Мы не используем `DateTimeOffset` напрямую, мы инжектируем `TimeProvider`;
* Всё, что может быть `internal sealed` им и остаётся;
* Осмысленно добавлять nuget-ы в только в необходимые проекты;
* Не нарушаем ссылки на проекты;
* Не используем efCore `Include()` ;
* Часто встречающиеся фильтрации упаковываем в спецификации. Например:`.ById(id); .ByIds(ids), .NotDeletedAt(timeProvider.GetUtcNow())`
* При добавлении нового репозитория добавляем его в `DbUnitOfWork`
* Сервисы наследуются от `BaseBusinessService`

## Naming моделей
* В бизнес слое:
1) Сущности без суффиксов
2) Модели для параметров в сервисах с суффиксом `Command` (`LaunchCommand`)
* В слое доступа к данным:
1) Сущности с суффиксом `Entity`
2) Модели, которые возвращаются репозиториями с суффиксом `Model`
* В слое презентации: модели только c суффиксами `Request` и `Response`
## Дизайн API
* Xml-комментарии на модели и контроллеры обязательны;
* `[ProducesResponseType()]` На каждый статус-код;
* REST!!!!!!!!!;
* Мы уважаем статус-коды 200,201,204,400,404,409,422 и в первую очередь думаем про них;
* Любые ошибки в коде упаковываем в ProblemDetails через фильтр;
* При дизайне урлов выделяем семантические группы. Например: `/api/v1/catalog/products`

## Пример работы с транзакциями 
```csharp
      await using (var transaction = DbUnitOfWork.BeginTransaction())
        {
            //Накапливаем изменения
            DbUnitOfWork.EmployeeRepository.Add(Mapper.Map<Employee>(model));
            DbUnitOfWork.FilesRepository.Add(employeeDoc);
            //Сохраняем и коммитим транзакцию
            await DbUnitOfWork.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        }
```

## Логирование
* `LogError` - Для ошибок;
* `LogInformation` - Только бизнес-сценариев;
* `LogDebug` - Для инфраструктурных вещей (миграции, логирование запросов и т.д.)

## Тестирование
* Мы используем xUnit, FluentAssertions, Moq, AutoFixture, WebApplicationFactory;
* Unit-тесты пишем на сервисы и Utils-классы (парсеры, преобразователи и т.д.);
* Интеграционные тесты с использованием TestContainers пишем на все контроллеры и проверяем на все статус-коды и желательно на все случаем. Для этого используем сгенерированного клиента NSwag.
