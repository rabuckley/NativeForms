using FluentAssertions;
using NativeForms;
using NativeForms.Handlers;

namespace NativeForms.Tests.Handlers;

public class NativeDatePickerHandlerTests
{
    [Fact]
    public void Constructor_ShouldInitializeWithPropertyMapper()
    {
        // Arrange & Act
        var handler = new NativeDatePickerHandler();

        // Assert
        handler.Should().NotBeNull();
    }

    [Fact]
    public void PropertyMapper_ShouldNotBeNull()
    {
        // Arrange & Act
        var mapper = NativeDatePickerHandler.PropertyMapper;

        // Assert
        mapper.Should().NotBeNull();
    }

    [Fact]
    public void MapDate_WithNullPlatformView_ShouldNotThrow()
    {
        // Arrange
        var handler = new NativeDatePickerHandler();
        var picker = new NativeDatePicker { Date = new DateOnly(2025, 6, 15) };

        // Act - Bug #8: Verify null check in MapDate prevents exceptions
        Action act = () => NativeDatePickerHandler.MapDate(handler, picker);

        // Assert
        act.Should().NotThrow("MapDate should safely handle null PlatformView");
    }

    [Fact]
    public void MapMinimumDate_WithNullPlatformView_ShouldNotThrow()
    {
        // Arrange
        var handler = new NativeDatePickerHandler();
        var picker = new NativeDatePicker { MinimumDate = new DateOnly(2025, 1, 1) };

        // Act - Bug #8: Verify null check prevents exceptions
        Action act = () => NativeDatePickerHandler.MapMinimumDate(handler, picker);

        // Assert
        act.Should().NotThrow("MapMinimumDate should safely handle null PlatformView");
    }

    [Fact]
    public void MapMaximumDate_WithNullPlatformView_ShouldNotThrow()
    {
        // Arrange
        var handler = new NativeDatePickerHandler();
        var picker = new NativeDatePicker { MaximumDate = new DateOnly(2025, 12, 31) };

        // Act - Bug #8: Verify null check prevents exceptions
        Action act = () => NativeDatePickerHandler.MapMaximumDate(handler, picker);

        // Assert
        act.Should().NotThrow("MapMaximumDate should safely handle null PlatformView");
    }
}
