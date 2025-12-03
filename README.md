# WorkTrack.Common.Domain.Exceptions

Domain exceptions for WorkTrack microservices.

**Version**: 1.0.0  
**Status**: ✅ Ready for production

## Description

This library provides base domain exception classes for implementing DDD in WorkTrack microservices.

## Installation

```bash
dotnet add package WorkTrack.Common.Domain.Exceptions --source https://nuget.pkg.github.com/WorkTrack-Team/index.json
```

## Exception Classes

### DomainException
Base class for all domain exceptions.

### NotFoundException
Thrown when a requested entity is not found.

```csharp
throw new NotFoundException("Template", templateId);
```

### ConflictException
Thrown when optimistic concurrency conflict occurs.

```csharp
throw new ConflictException(expectedVersion: 1, actualVersion: 2, "Template");
```

### ValidationException
Thrown when validation errors occur.

```csharp
var errors = new Dictionary<string, string[]>
{
    { "Name", new[] { "Name is required" } }
};
throw new ValidationException(errors);
```

### BusinessRuleViolationException
Thrown when business rule is violated.

```csharp
throw new BusinessRuleViolationException("RULE001", "Cannot delete published template");
```

## License

MIT

## Repository

https://github.com/WorkTrack-Team/WorkTrack.Common.Domain.Exceptions

