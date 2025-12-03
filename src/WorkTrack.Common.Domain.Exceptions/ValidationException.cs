using Ardalis.GuardClauses;

namespace WorkTrack.Common.Domain.Exceptions;

/// <summary>
/// Исключение, возникающее при ошибке валидации данных.
/// </summary>
public class ValidationException : DomainException
{
    /// <summary>
    /// Словарь ошибок валидации по полям.
    /// </summary>
    public IReadOnlyDictionary<string, string[]> Errors { get; }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="ValidationException"/>.
    /// </summary>
    public ValidationException()
        : base("Произошла одна или несколько ошибок валидации.") =>
        Errors = new Dictionary<string, string[]>();

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="ValidationException"/>.
    /// </summary>
    /// <param name="message">Сообщение об ошибке.</param>
    public ValidationException(string message)
        : base(Guard.Against.NullOrWhiteSpace(message)) =>
        Errors = new Dictionary<string, string[]>();

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="ValidationException"/>.
    /// </summary>
    /// <param name="errors">Словарь ошибок валидации.</param>
    public ValidationException(IDictionary<string, string[]> errors)
        : base("Произошла одна или несколько ошибок валидации.") =>
        Errors = Guard.Against.Null(errors).AsReadOnly();

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="ValidationException"/>.
    /// </summary>
    /// <param name="fieldName">Имя поля с ошибкой.</param>
    /// <param name="errorMessage">Сообщение об ошибке.</param>
    public ValidationException(string fieldName, string errorMessage)
        : base($"Ошибка валидации поля '{Guard.Against.NullOrWhiteSpace(fieldName)}': {Guard.Against.NullOrWhiteSpace(errorMessage)}")
    {
        Errors = new Dictionary<string, string[]>
        {
            { fieldName, new[] { errorMessage } },
        };
    }
}

/// <summary>
/// Расширения для словаря ошибок валидации.
/// </summary>
internal static class DictionaryExtensions
{
    /// <summary>
    /// Преобразует словарь в read-only.
    /// </summary>
    public static IReadOnlyDictionary<TKey, TValue> AsReadOnly<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        where TKey : notnull =>
        new Dictionary<TKey, TValue>(dictionary, StringComparer.Ordinal as IEqualityComparer<TKey>);
}
