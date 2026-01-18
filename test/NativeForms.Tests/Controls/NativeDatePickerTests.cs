using FluentAssertions;
using NativeForms;

namespace NativeForms.Tests.Controls;

public class NativeDatePickerTests
{
    [Fact]
    public void Constructor_ShouldInitializeWithDefaultValues()
    {
        // Arrange & Act
        var picker = new NativeDatePicker();

        // Assert
        picker.Date.Should().Be(DateOnly.MinValue, "default Date should be DateOnly.MinValue");
        picker.MinimumDate.Should().Be(DateOnly.MinValue, "default MinimumDate should be DateOnly.MinValue");
        picker.MaximumDate.Should().Be(DateOnly.MaxValue, "default MaximumDate should be DateOnly.MaxValue");
    }

    [Fact]
    public void DateProperty_ShouldSupportTwoWayBinding()
    {
        // Arrange
        var picker = new NativeDatePicker();
        var newDate = new DateOnly(2025, 6, 15);

        // Act
        picker.Date = newDate;

        // Assert
        picker.Date.Should().Be(newDate);
        NativeDatePicker.DateProperty.DefaultBindingMode.Should().Be(Microsoft.Maui.Controls.BindingMode.TwoWay,
            "Date property should support two-way binding");
    }

    [Fact]
    public void MinimumDateProperty_ShouldSupportOneWayBinding()
    {
        // Arrange
        var picker = new NativeDatePicker();
        var newMinimum = new DateOnly(2025, 1, 1);

        // Act
        picker.MinimumDate = newMinimum;

        // Assert
        picker.MinimumDate.Should().Be(newMinimum);
        NativeDatePicker.MinimumDateProperty.DefaultBindingMode.Should().Be(Microsoft.Maui.Controls.BindingMode.OneWay,
            "MinimumDate property should use one-way binding");
    }

    [Fact]
    public void MaximumDateProperty_ShouldSupportOneWayBinding()
    {
        // Arrange
        var picker = new NativeDatePicker();
        var newMaximum = new DateOnly(2025, 12, 31);

        // Act
        picker.MaximumDate = newMaximum;

        // Assert
        picker.MaximumDate.Should().Be(newMaximum);
        NativeDatePicker.MaximumDateProperty.DefaultBindingMode.Should().Be(Microsoft.Maui.Controls.BindingMode.OneWay,
            "MaximumDate property should use one-way binding");
    }

    [Fact]
    public void Date_ShouldBeSettableIndependently()
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
        picker.Date.Should().Be(new DateOnly(2025, 6, 15));
    }

    [Fact]
    public void Properties_ShouldBeSettableInAnyOrder()
    {
        // Arrange & Act
        var picker = new NativeDatePicker
        {
            Date = new DateOnly(2025, 6, 15),
            MaximumDate = new DateOnly(2025, 12, 31),
            MinimumDate = new DateOnly(2025, 1, 1)
        };

        // Assert - Date may be adjusted by validation, but all properties should be set
        picker.MinimumDate.Should().Be(new DateOnly(2025, 1, 1));
        picker.MaximumDate.Should().Be(new DateOnly(2025, 12, 31));
        picker.Date.Should().BeOnOrAfter(picker.MinimumDate).And.BeOnOrBefore(picker.MaximumDate);
    }
}
