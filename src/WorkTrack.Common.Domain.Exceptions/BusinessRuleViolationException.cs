using Ardalis.GuardClauses;

namespace WorkTrack.Common.Domain.Exceptions;

/// <summary>
/// Исключение, возникающее при нарушении бизнес-правила.
/// </summary>
public class BusinessRuleViolationException : DomainException
{
    /// <summary>
    /// Код бизнес-правила, которое было нарушено.
    /// </summary>
    public string RuleCode { get; }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="BusinessRuleViolationException"/>.
    /// </summary>
    /// <param name="message">Сообщение об ошибке.</param>
    public BusinessRuleViolationException(string message)
        : base(Guard.Against.NullOrWhiteSpace(message)) =>
        RuleCode = string.Empty;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="BusinessRuleViolationException"/>.
    /// </summary>
    /// <param name="ruleCode">Код бизнес-правила.</param>
    /// <param name="message">Сообщение об ошибке.</param>
    public BusinessRuleViolationException(string ruleCode, string message)
        : base(Guard.Against.NullOrWhiteSpace(message)) =>
        RuleCode = Guard.Against.NullOrWhiteSpace(ruleCode);

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="BusinessRuleViolationException"/>.
    /// </summary>
    /// <param name="message">Сообщение об ошибке.</param>
    /// <param name="innerException">Внутреннее исключение.</param>
    public BusinessRuleViolationException(string message, Exception innerException)
        : base(Guard.Against.NullOrWhiteSpace(message), Guard.Against.Null(innerException)) =>
        RuleCode = string.Empty;
}
