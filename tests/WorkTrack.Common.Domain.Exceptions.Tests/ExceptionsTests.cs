using FluentAssertions;
using Xunit;

namespace WorkTrack.Common.Domain.Exceptions.Tests;

public sealed class ExceptionsTests
{
    [Fact]
    public void NotFoundException_WithEntityTypeAndId_ShouldSetProperties()
    {
        // Arrange
        var entityType = "Template";
        var entityId = Guid.NewGuid();

        // Act
        var exception = new NotFoundException(entityType, entityId);

        // Assert
        exception.EntityType.Should().Be(entityType);
        exception.EntityId.Should().Be(entityId);
        exception.Message.Should().Contain(entityType);
        exception.Message.Should().Contain(entityId.ToString());
    }

    [Fact]
    public void ConflictException_WithVersions_ShouldSetProperties()
    {
        // Arrange
        var expectedVersion = 1;
        var actualVersion = 2;

        // Act
        var exception = new ConflictException(expectedVersion, actualVersion, "Template");

        // Assert
        exception.ExpectedVersion.Should().Be(expectedVersion);
        exception.ActualVersion.Should().Be(actualVersion);
        exception.Message.Should().Contain("1");
        exception.Message.Should().Contain("2");
    }

    [Fact]
    public void ValidationException_WithErrors_ShouldSetProperties()
    {
        // Arrange
        var errors = new Dictionary<string, string[]>
        {
            { "Name", ["Name is required"] },
            { "Email", ["Invalid email format"] },
        };

        // Act
        var exception = new ValidationException(errors);

        // Assert
        exception.Errors.Should().HaveCount(2);
        exception.Errors["Name"].Should().Contain("Name is required");
        exception.Errors["Email"].Should().Contain("Invalid email format");
    }

    [Fact]
    public void ValidationException_WithFieldNameAndError_ShouldSetProperties()
    {
        // Arrange
        var fieldName = "Name";
        var errorMessage = "Name is required";

        // Act
        var exception = new ValidationException(fieldName, errorMessage);

        // Assert
        exception.Errors.Should().ContainKey(fieldName);
        exception.Errors[fieldName].Should().Contain(errorMessage);
    }

    [Fact]
    public void BusinessRuleViolationException_WithRuleCode_ShouldSetProperties()
    {
        // Arrange
        var ruleCode = "RULE001";
        var message = "Business rule violated";

        // Act
        var exception = new BusinessRuleViolationException(ruleCode, message);

        // Assert
        exception.RuleCode.Should().Be(ruleCode);
        exception.Message.Should().Be(message);
    }

    [Fact]
    public void DomainException_ShouldBeBaseForAllExceptions()
    {
        // Assert
        typeof(NotFoundException).Should().BeDerivedFrom<DomainException>();
        typeof(ConflictException).Should().BeDerivedFrom<DomainException>();
        typeof(ValidationException).Should().BeDerivedFrom<DomainException>();
        typeof(BusinessRuleViolationException).Should().BeDerivedFrom<DomainException>();
    }
}


