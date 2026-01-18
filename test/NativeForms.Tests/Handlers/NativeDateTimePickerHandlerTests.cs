using FluentAssertions;
using NativeForms;
using NativeForms.Handlers;

namespace NativeForms.Tests.Handlers;

public class NativeDateTimePickerHandlerTests
{
    [Fact]
    public void Constructor_ShouldInitializeWithPropertyMapper()
    {
        // Arrange & Act
        var handler = new NativeDateTimePickerHandler();

        // Assert
        handler.Should().NotBeNull();
    }

    [Fact]
    public void PropertyMapper_ShouldNotBeNull()
    {
        // Arrange & Act
        var mapper = NativeDateTimePickerHandler.PropertyMapper;

        // Assert
        mapper.Should().NotBeNull();
    }

    [Fact]
    public void MapDate_WithNullPlatformView_ShouldNotThrow()
    {
        // Arrange
        var handler = new NativeDateTimePickerHandler();
        var picker = new NativeDateTimePicker { DateTime = new DateTime(2025, 6, 15, 14, 30, 0) };

        // Act - Bug #8: Verify null check in MapDate prevents exceptions
        Action act = () => NativeDateTimePickerHandler.MapDate(handler, picker);

        // Assert
        act.Should().NotThrow("MapDate should safely handle null PlatformView");
    }

    [Fact]
    public void MapMinimumDate_WithNullPlatformView_ShouldNotThrow()
    {
        // Arrange
        var handler = new NativeDateTimePickerHandler();
        var picker = new NativeDateTimePicker { MinimumDateTime = new DateTime(2025, 1, 1, 0, 0, 0) };

        // Act - Bug #8: Verify null check prevents exceptions
        Action act = () => NativeDateTimePickerHandler.MapMinimumDate(handler, picker);

        // Assert
        act.Should().NotThrow("MapMinimumDate should safely handle null PlatformView");
    }

    [Fact]
    public void MapMaximumDate_WithNullPlatformView_ShouldNotThrow()
    {
        // Arrange
        var handler = new NativeDateTimePickerHandler();
        var picker = new NativeDateTimePicker { MaximumDateTime = new DateTime(2025, 12, 31, 23, 59, 59) };

        // Act - Bug #8: Verify null check prevents exceptions
        Action act = () => NativeDateTimePickerHandler.MapMaximumDate(handler, picker);

        // Assert
        act.Should().NotThrow("MapMaximumDate should safely handle null PlatformView");
    }
}
