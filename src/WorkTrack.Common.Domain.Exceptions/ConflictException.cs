using Ardalis.GuardClauses;

namespace WorkTrack.Common.Domain.Exceptions;

/// <summary>
/// Исключение, возникающее при конфликте версий (optimistic concurrency).
/// </summary>
public class ConflictException : DomainException
{
    /// <summary>
    /// Ожидаемая версия ресурса.
    /// </summary>
    public int ExpectedVersion { get; }

    /// <summary>
    /// Фактическая версия ресурса.
    /// </summary>
    public int ActualVersion { get; }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="ConflictException"/>.
    /// </summary>
    public ConflictException()
        : base("Произошел конфликт версий при обновлении ресурса.")
    {
        ExpectedVersion = 0;
        ActualVersion = 0;
    }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="ConflictException"/>.
    /// </summary>
    /// <param name="message">Сообщение об ошибке.</param>
    public ConflictException(string message)
        : base(Guard.Against.NullOrWhiteSpace(message))
    {
        ExpectedVersion = 0;
        ActualVersion = 0;
    }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="ConflictException"/>.
    /// </summary>
    /// <param name="message">Сообщение об ошибке.</param>
    /// <param name="innerException">Внутреннее исключение.</param>
    public ConflictException(string message, Exception innerException)
        : base(Guard.Against.NullOrWhiteSpace(message), Guard.Against.Null(innerException))
    {
        ExpectedVersion = 0;
        ActualVersion = 0;
    }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="ConflictException"/>.
    /// </summary>
    /// <param name="expectedVersion">Ожидаемая версия ресурса.</param>
    /// <param name="actualVersion">Фактическая версия ресурса.</param>
    /// <param name="resourceName">Название ресурса.</param>
    public ConflictException(int expectedVersion, int actualVersion, string? resourceName = null)
        : base(BuildMessage(expectedVersion, actualVersion, resourceName))
    {
        Guard.Against.NegativeOrZero(expectedVersion);
        Guard.Against.NegativeOrZero(actualVersion);
        ExpectedVersion = expectedVersion;
        ActualVersion = actualVersion;
    }

    private static string BuildMessage(int expectedVersion, int actualVersion, string? resourceName)
    {
        var resource = string.IsNullOrWhiteSpace(resourceName) ? "Ресурс" : resourceName;
        return $"{resource} был изменен другим пользователем. Ожидалась версия {expectedVersion}, текущая версия {actualVersion}.";
    }
}
