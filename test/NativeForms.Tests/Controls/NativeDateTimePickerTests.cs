using FluentAssertions;
using NativeForms;

namespace NativeForms.Tests.Controls;

public class NativeDateTimePickerTests
{
    [Fact]
    public void Constructor_ShouldInitializeWithDefaultValues()
    {
        // Arrange & Act
        var picker = new NativeDateTimePicker();

        // Assert
        picker.DateTime.Should().Be(default(DateTime), "default DateTime should be default(DateTime)");
        picker.MinimumDateTime.Should().Be(DateTime.MinValue, "default MinimumDateTime should be DateTime.MinValue");
        picker.MaximumDateTime.Should().Be(DateTime.MaxValue, "default MaximumDateTime should be DateTime.MaxValue");
    }

    [Fact]
    public void DateTimeProperty_ShouldSupportTwoWayBinding()
    {
        // Arrange
        var picker = new NativeDateTimePicker();
        var newDateTime = new DateTime(2025, 6, 15, 14, 30, 0);

        // Act
        picker.DateTime = newDateTime;

        // Assert
        picker.DateTime.Should().Be(newDateTime);
        NativeDateTimePicker.DateTimeProperty.DefaultBindingMode.Should().Be(Microsoft.Maui.Controls.BindingMode.TwoWay,
            "DateTime property should support two-way binding");
    }

    [Fact]
    public void MinimumDateTimeProperty_ShouldSupportOneWayBinding()
    {
        // Arrange
        var picker = new NativeDateTimePicker();
        var newMinimum = new DateTime(2025, 1, 1, 0, 0, 0);

        // Act
        picker.MinimumDateTime = newMinimum;

        // Assert
        picker.MinimumDateTime.Should().Be(newMinimum);
        NativeDateTimePicker.MinimumDateTimeProperty.DefaultBindingMode.Should().Be(Microsoft.Maui.Controls.BindingMode.OneWay,
            "MinimumDateTime property should use one-way binding");
    }

    [Fact]
    public void MaximumDateTimeProperty_ShouldSupportOneWayBinding()
    {
        // Arrange
        var picker = new NativeDateTimePicker();
        var newMaximum = new DateTime(2025, 12, 31, 23, 59, 59);

        // Act
        picker.MaximumDateTime = newMaximum;

        // Assert
        picker.MaximumDateTime.Should().Be(newMaximum);
        NativeDateTimePicker.MaximumDateTimeProperty.DefaultBindingMode.Should().Be(Microsoft.Maui.Controls.BindingMode.OneWay,
            "MaximumDateTime property should use one-way binding");
    }

    [Fact]
    public void DateTime_ShouldBeSettableIndependently()
    {
        // Arrange
        var picker = new NativeDateTimePicker
        {
            MinimumDateTime = new DateTime(2025, 1, 1, 0, 0, 0),
            MaximumDateTime = new DateTime(2025, 12, 31, 23, 59, 59)
        };

        // Act
        picker.DateTime = new DateTime(2025, 6, 15, 12, 30, 0);

        // Assert
        picker.DateTime.Should().Be(new DateTime(2025, 6, 15, 12, 30, 0));
    }
}
