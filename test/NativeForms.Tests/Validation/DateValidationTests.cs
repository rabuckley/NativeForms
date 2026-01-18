using FluentAssertions;
using NativeForms;

namespace NativeForms.Tests.Validation;

public class DateValidationTests
{
    [Fact]
    public void MinimumDate_WhenSetGreaterThanMaximum_ShouldAdjustMaximum()
    {
        // Arrange
        var picker = new NativeDatePicker
        {
            MaximumDate = new DateOnly(2025, 6, 30)
        };

        // Act
        picker.MinimumDate = new DateOnly(2025, 12, 1);

        // Assert
        picker.MinimumDate.Should().Be(new DateOnly(2025, 12, 1));
        picker.MaximumDate.Should().Be(new DateOnly(2025, 12, 1), "MaximumDate should be adjusted to match MinimumDate");
    }

    [Fact]
    public void MaximumDate_WhenSetLessThanMinimum_ShouldAdjustMinimum()
    {
        // Arrange
        var picker = new NativeDatePicker
        {
            MinimumDate = new DateOnly(2025, 6, 1)
        };

        // Act
        picker.MaximumDate = new DateOnly(2025, 3, 15);

        // Assert
        picker.MaximumDate.Should().Be(new DateOnly(2025, 3, 15));
        picker.MinimumDate.Should().Be(new DateOnly(2025, 3, 15), "MinimumDate should be adjusted to match MaximumDate");
    }

    [Fact]
    public void Date_WhenLessThanMinimum_ShouldClampToMinimum()
    {
        // Arrange
        var picker = new NativeDatePicker
        {
            Date = new DateOnly(2025, 6, 15)
        };

        // Act
        picker.MinimumDate = new DateOnly(2025, 9, 1);

        // Assert
        picker.Date.Should().Be(new DateOnly(2025, 9, 1), "Date should be clamped to MinimumDate");
    }

    [Fact]
    public void Date_WhenGreaterThanMaximum_ShouldClampToMaximum()
    {
        // Arrange
        var picker = new NativeDatePicker
        {
            Date = new DateOnly(2025, 9, 15)
        };

        // Act
        picker.MaximumDate = new DateOnly(2025, 6, 30);

        // Assert
        picker.Date.Should().Be(new DateOnly(2025, 6, 30), "Date should be clamped to MaximumDate");
    }

    [Fact]
    public void MinimumAndMaximumDate_WhenSetSimultaneously_ShouldNotCauseInfiniteLoop()
    {
        // Arrange
        var picker = new NativeDatePicker();

        // Act - This tests the critical circular validation fix (Bug #1)
        Action act = () =>
        {
            picker.MinimumDate = new DateOnly(2025, 12, 31);
            picker.MaximumDate = new DateOnly(2025, 1, 1);
        };

        // Assert
        act.Should().NotThrow("the validation logic should handle conflicting bounds without infinite recursion");
        picker.MinimumDate.Should().Be(new DateOnly(2025, 1, 1), "MinimumDate should be adjusted by MaximumDate setter");
        picker.MaximumDate.Should().Be(new DateOnly(2025, 1, 1));
    }

    [Fact]
    public void EdgeCase_MinValue_ShouldWork()
    {
        // Arrange
        var picker = new NativeDatePicker();

        // Act
        picker.MinimumDate = DateOnly.MinValue;
        picker.MaximumDate = DateOnly.MinValue.AddDays(10);
        picker.Date = DateOnly.MinValue.AddDays(5);

        // Assert
        picker.MinimumDate.Should().Be(DateOnly.MinValue);
        picker.MaximumDate.Should().Be(DateOnly.MinValue.AddDays(10));
        picker.Date.Should().Be(DateOnly.MinValue.AddDays(5));
    }

    [Fact]
    public void EdgeCase_MaxValue_ShouldWork()
    {
        // Arrange
        var picker = new NativeDatePicker();

        // Act
        picker.MaximumDate = DateOnly.MaxValue;
        picker.MinimumDate = DateOnly.MaxValue.AddDays(-10);
        picker.Date = DateOnly.MaxValue.AddDays(-5);

        // Assert
        picker.MaximumDate.Should().Be(DateOnly.MaxValue);
        picker.MinimumDate.Should().Be(DateOnly.MaxValue.AddDays(-10));
        picker.Date.Should().Be(DateOnly.MaxValue.AddDays(-5));
    }

    [Fact]
    public void Date_WhenWithinBounds_ShouldNotBeModified()
    {
        // Arrange
        var picker = new NativeDatePicker
        {
            MinimumDate = new DateOnly(2025, 1, 1),
            MaximumDate = new DateOnly(2025, 12, 31)
        };

        // Act
        picker.Date = new DateOnly(2025, 6, 15);

        // Assert
        picker.Date.Should().Be(new DateOnly(2025, 6, 15), "Date is within bounds and should not be modified");
    }
}
