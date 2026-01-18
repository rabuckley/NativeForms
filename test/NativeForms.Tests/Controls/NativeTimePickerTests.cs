using FluentAssertions;
using NativeForms;

namespace NativeForms.Tests.Controls;

public class NativeTimePickerTests
{
    [Fact]
    public void Constructor_ShouldInitializeWithDefaultValues()
    {
        // Arrange & Act
        var picker = new NativeTimePicker();

        // Assert
        picker.Time.Should().Be(TimeOnly.MinValue, "default Time should be TimeOnly.MinValue");
        picker.MinimumTime.Should().Be(TimeOnly.MinValue, "default MinimumTime should be TimeOnly.MinValue");
        picker.MaximumTime.Should().Be(TimeOnly.MaxValue, "default MaximumTime should be TimeOnly.MaxValue");
    }

    [Fact]
    public void TimeProperty_ShouldSupportTwoWayBinding()
    {
        // Arrange
        var picker = new NativeTimePicker();
        var newTime = new TimeOnly(14, 30);

        // Act
        picker.Time = newTime;

        // Assert
        picker.Time.Should().Be(newTime);
        NativeTimePicker.TimeProperty.DefaultBindingMode.Should().Be(Microsoft.Maui.Controls.BindingMode.TwoWay,
            "Time property should support two-way binding");
    }

    [Fact]
    public void MinimumTimeProperty_ShouldSupportOneWayBinding()
    {
        // Arrange
        var picker = new NativeTimePicker();
        var newMinimum = new TimeOnly(9, 0);

        // Act
        picker.MinimumTime = newMinimum;

        // Assert
        picker.MinimumTime.Should().Be(newMinimum);
        NativeTimePicker.MinimumTimeProperty.DefaultBindingMode.Should().Be(Microsoft.Maui.Controls.BindingMode.OneWay,
            "MinimumTime property should use one-way binding");
    }

    [Fact]
    public void MaximumTimeProperty_ShouldSupportOneWayBinding()
    {
        // Arrange
        var picker = new NativeTimePicker();
        var newMaximum = new TimeOnly(17, 0);

        // Act
        picker.MaximumTime = newMaximum;

        // Assert
        picker.MaximumTime.Should().Be(newMaximum);
        NativeTimePicker.MaximumTimeProperty.DefaultBindingMode.Should().Be(Microsoft.Maui.Controls.BindingMode.OneWay,
            "MaximumTime property should use one-way binding");
    }

    [Fact]
    public void Time_ShouldBeSettableIndependently()
    {
        // Arrange
        var picker = new NativeTimePicker
        {
            MinimumTime = new TimeOnly(9, 0),
            MaximumTime = new TimeOnly(17, 0)
        };

        // Act
        picker.Time = new TimeOnly(12, 30);

        // Assert
        picker.Time.Should().Be(new TimeOnly(12, 30));
    }
}
