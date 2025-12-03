using Ardalis.GuardClauses;

namespace WorkTrack.Common.Domain.Exceptions;

/// <summary>
/// Исключение, возникающее при отсутствии запрашиваемой сущности.
/// </summary>
public class NotFoundException : DomainException
{
    /// <summary>
    /// Тип сущности, которая не была найдена.
    /// </summary>
    public string EntityType { get; }

    /// <summary>
    /// Идентификатор сущности, которая не была найдена.
    /// </summary>
    public object EntityId { get; }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="NotFoundException"/>.
    /// </summary>
    /// <param name="entityType">Тип сущности.</param>
    /// <param name="entityId">Идентификатор сущности.</param>
    public NotFoundException(string entityType, object entityId)
        : base($"{Guard.Against.NullOrWhiteSpace(entityType)} с идентификатором '{Guard.Against.Null(entityId)}' не найден.")
    {
        EntityType = entityType;
        EntityId = entityId;
    }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="NotFoundException"/>.
    /// </summary>
    /// <param name="message">Сообщение об ошибке.</param>
    public NotFoundException(string message)
        : base(Guard.Against.NullOrWhiteSpace(message))
    {
        EntityType = string.Empty;
        EntityId = string.Empty;
    }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="NotFoundException"/>.
    /// </summary>
    /// <param name="message">Сообщение об ошибке.</param>
    /// <param name="innerException">Внутреннее исключение.</param>
    public NotFoundException(string message, Exception innerException)
        : base(Guard.Against.NullOrWhiteSpace(message), Guard.Against.Null(innerException))
    {
        EntityType = string.Empty;
        EntityId = string.Empty;
    }
}
