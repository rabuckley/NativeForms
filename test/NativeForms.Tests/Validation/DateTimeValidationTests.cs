using FluentAssertions;
using NativeForms;

namespace NativeForms.Tests.Validation;

public class DateTimeValidationTests
{
    [Fact]
    public void DefaultDateTime_ShouldBeDefaultValue_NotDateTimeNow()
    {
        // Arrange & Act - Critical test for Bug #7
        var picker = new NativeDateTimePicker();

        // Assert
        picker.DateTime.Should().Be(default(DateTime),
            "default should be default(DateTime) not DateTime.Now to avoid static evaluation issues");
        picker.DateTime.Should().Be(DateTime.MinValue);
    }

    [Fact]
    public void MinimumDateTime_WhenSetGreaterThanMaximum_ShouldAdjustMaximum()
    {
        // Arrange
        var picker = new NativeDateTimePicker
        {
            MaximumDateTime = new DateTime(2025, 6, 30, 12, 0, 0)
        };

        // Act
        picker.MinimumDateTime = new DateTime(2025, 12, 1, 15, 30, 0);

        // Assert
        picker.MinimumDateTime.Should().Be(new DateTime(2025, 12, 1, 15, 30, 0));
        picker.MaximumDateTime.Should().Be(new DateTime(2025, 12, 1, 15, 30, 0),
            "MaximumDateTime should be adjusted to match MinimumDateTime");
    }

    [Fact]
    public void MaximumDateTime_WhenSetLessThanMinimum_ShouldAdjustMinimum()
    {
        // Arrange
        var picker = new NativeDateTimePicker
        {
            MinimumDateTime = new DateTime(2025, 6, 1, 9, 0, 0)
        };

        // Act
        picker.MaximumDateTime = new DateTime(2025, 3, 15, 17, 30, 0);

        // Assert
        picker.MaximumDateTime.Should().Be(new DateTime(2025, 3, 15, 17, 30, 0));
        picker.MinimumDateTime.Should().Be(new DateTime(2025, 3, 15, 17, 30, 0),
            "MinimumDateTime should be adjusted to match MaximumDateTime");
    }

    [Fact]
    public void DateTime_WhenLessThanMinimum_ShouldClampToMinimum()
    {
        // Arrange
        var picker = new NativeDateTimePicker
        {
            DateTime = new DateTime(2025, 6, 15, 10, 30, 0)
        };

        // Act
        picker.MinimumDateTime = new DateTime(2025, 9, 1, 8, 0, 0);

        // Assert
        picker.DateTime.Should().Be(new DateTime(2025, 9, 1, 8, 0, 0),
            "DateTime should be clamped to MinimumDateTime");
    }

    [Fact]
    public void DateTime_WhenGreaterThanMaximum_ShouldClampToMaximum()
    {
        // Arrange
        var picker = new NativeDateTimePicker
        {
            DateTime = new DateTime(2025, 9, 15, 14, 0, 0)
        };

        // Act
        picker.MaximumDateTime = new DateTime(2025, 6, 30, 18, 0, 0);

        // Assert
        picker.DateTime.Should().Be(new DateTime(2025, 6, 30, 18, 0, 0),
            "DateTime should be clamped to MaximumDateTime");
    }

    [Fact]
    public void MinimumAndMaximumDateTime_WhenSetSimultaneously_ShouldNotCauseInfiniteLoop()
    {
        // Arrange
        var picker = new NativeDateTimePicker();

        // Act - This tests the critical circular validation fix (Bug #1)
        Action act = () =>
        {
            picker.MinimumDateTime = new DateTime(2025, 12, 31, 23, 59, 59);
            picker.MaximumDateTime = new DateTime(2025, 1, 1, 0, 0, 0);
        };

        // Assert
        act.Should().NotThrow("the validation logic should handle conflicting bounds without infinite recursion");
        picker.MinimumDateTime.Should().Be(new DateTime(2025, 1, 1, 0, 0, 0),
            "MinimumDateTime should be adjusted by MaximumDateTime setter");
        picker.MaximumDateTime.Should().Be(new DateTime(2025, 1, 1, 0, 0, 0));
    }
}
