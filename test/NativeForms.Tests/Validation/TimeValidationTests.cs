using FluentAssertions;
using NativeForms;

namespace NativeForms.Tests.Validation;

public class TimeValidationTests
{
    [Fact]
    public void MinimumTime_WhenSetGreaterThanMaximum_ShouldAdjustMaximum()
    {
        // Arrange
        var picker = new NativeTimePicker
        {
            MaximumTime = new TimeOnly(12, 0)
        };

        // Act
        picker.MinimumTime = new TimeOnly(18, 30);

        // Assert
        picker.MinimumTime.Should().Be(new TimeOnly(18, 30));
        picker.MaximumTime.Should().Be(new TimeOnly(18, 30), "MaximumTime should be adjusted to match MinimumTime");
    }

    [Fact]
    public void MaximumTime_WhenSetLessThanMinimum_ShouldAdjustMinimum()
    {
        // Arrange
        var picker = new NativeTimePicker
        {
            MinimumTime = new TimeOnly(15, 0)
        };

        // Act
        picker.MaximumTime = new TimeOnly(9, 30);

        // Assert
        picker.MaximumTime.Should().Be(new TimeOnly(9, 30));
        picker.MinimumTime.Should().Be(new TimeOnly(9, 30), "MinimumTime should be adjusted to match MaximumTime");
    }

    [Fact]
    public void Time_WhenLessThanMinimum_ShouldClampToMinimum()
    {
        // Arrange
        var picker = new NativeTimePicker
        {
            Time = new TimeOnly(10, 0)
        };

        // Act
        picker.MinimumTime = new TimeOnly(14, 30);

        // Assert
        picker.Time.Should().Be(new TimeOnly(14, 30), "Time should be clamped to MinimumTime");
    }

    [Fact]
    public void Time_WhenGreaterThanMaximum_ShouldClampToMaximum()
    {
        // Arrange
        var picker = new NativeTimePicker
        {
            Time = new TimeOnly(18, 0)
        };

        // Act
        picker.MaximumTime = new TimeOnly(12, 0);

        // Assert
        picker.Time.Should().Be(new TimeOnly(12, 0), "Time should be clamped to MaximumTime");
    }

    [Fact]
    public void MinimumAndMaximumTime_WhenSetSimultaneously_ShouldNotCauseInfiniteLoop()
    {
        // Arrange
        var picker = new NativeTimePicker();

        // Act - This tests the critical circular validation fix (Bug #1)
        Action act = () =>
        {
            picker.MinimumTime = new TimeOnly(23, 59);
            picker.MaximumTime = new TimeOnly(0, 0);
        };

        // Assert
        act.Should().NotThrow("the validation logic should handle conflicting bounds without infinite recursion");
        picker.MinimumTime.Should().Be(new TimeOnly(0, 0), "MinimumTime should be adjusted by MaximumTime setter");
        picker.MaximumTime.Should().Be(new TimeOnly(0, 0));
    }

    [Fact]
    public void EdgeCase_Midnight_ShouldWork()
    {
        // Arrange
        var picker = new NativeTimePicker();

        // Act
        picker.MinimumTime = TimeOnly.MinValue; // 00:00:00
        picker.MaximumTime = new TimeOnly(1, 0);
        picker.Time = new TimeOnly(0, 30);

        // Assert
        picker.MinimumTime.Should().Be(TimeOnly.MinValue);
        picker.MaximumTime.Should().Be(new TimeOnly(1, 0));
        picker.Time.Should().Be(new TimeOnly(0, 30));
    }
}
