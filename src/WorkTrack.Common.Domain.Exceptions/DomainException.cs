namespace WorkTrack.Common.Domain.Exceptions;

/// <summary>
/// Базовый класс для всех доменных исключений.
/// </summary>
public abstract class DomainException : Exception
{
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="DomainException"/>.
    /// </summary>
    protected DomainException()
    {
    }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="DomainException"/>.
    /// </summary>
    /// <param name="message">Сообщение об ошибке.</param>
    protected DomainException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="DomainException"/>.
    /// </summary>
    /// <param name="message">Сообщение об ошибке.</param>
    /// <param name="innerException">Внутреннее исключение.</param>
    protected DomainException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
