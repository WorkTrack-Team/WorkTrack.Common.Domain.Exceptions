# WorkTrack.Common.Domain.Exceptions

Доменные исключения для микросервисов WorkTrack.

**Версия**: 1.0.0  
**Статус**: ✅ Готов к production

## Описание

Библиотека предоставляет базовые классы доменных исключений для реализации DDD в микросервисах WorkTrack.

## Установка

```bash
dotnet add package WorkTrack.Common.Domain.Exceptions --source https://nuget.pkg.github.com/WorkTrack-Team/index.json
```

## Классы исключений

### DomainException
Базовый класс для всех доменных исключений.

### NotFoundException
Исключение, возникающее при отсутствии запрашиваемой сущности.

```csharp
throw new NotFoundException("Template", templateId);
```

### ConflictException
Исключение, возникающее при конфликте версий (optimistic concurrency).

```csharp
throw new ConflictException(expectedVersion: 1, actualVersion: 2, "Template");
```

### ValidationException
Исключение, возникающее при ошибках валидации.

```csharp
var errors = new Dictionary<string, string[]>
{
    { "Name", new[] { "Имя обязательно" } }
};
throw new ValidationException(errors);
```

### BusinessRuleViolationException
Исключение, возникающее при нарушении бизнес-правил.

```csharp
throw new BusinessRuleViolationException("RULE001", "Нельзя удалить опубликованный шаблон");
```

## Использование в проекте

```csharp
public class TemplateService
{
    public async Task<Template> GetByIdAsync(Guid id)
    {
        var template = await _repository.GetByIdAsync(id);
        
        if (template == null)
            throw new NotFoundException("Template", id);
            
        return template;
    }
    
    public async Task UpdateAsync(Template template, int expectedVersion)
    {
        var current = await _repository.GetByIdAsync(template.Id);
        
        if (current.Version != expectedVersion)
            throw new ConflictException(expectedVersion, current.Version, "Template");
            
        await _repository.UpdateAsync(template);
    }
}
```

## Лицензия

MIT

## Репозиторий

https://github.com/WorkTrack-Team/WorkTrack.Common.Domain.Exceptions

## Связанные пакеты

- **WorkTrack.Common.Domain.ValueObjects** - Базовый класс ValueObject
- **Ardalis.GuardClauses** - Валидация аргументов
