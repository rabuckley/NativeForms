using FluentAssertions;
using NativeForms;
using NativeForms.Handlers;

namespace NativeForms.Tests.Handlers;

public class NativeTimePickerHandlerTests
{
    [Fact]
    public void Constructor_ShouldInitializeWithPropertyMapper()
    {
        // Arrange & Act
        var handler = new NativeTimePickerHandler();

        // Assert
        handler.Should().NotBeNull();
    }

    [Fact]
    public void PropertyMapper_ShouldNotBeNull()
    {
        // Arrange & Act
        var mapper = NativeTimePickerHandler.PropertyMapper;

        // Assert
        mapper.Should().NotBeNull();
    }

    [Fact]
    public void MapTime_WithNullPlatformView_ShouldNotThrow()
    {
        // Arrange
        var handler = new NativeTimePickerHandler();
        var picker = new NativeTimePicker { Time = new TimeOnly(14, 30) };

        // Act - Bug #8: Verify null check in MapTime prevents exceptions
        Action act = () => NativeTimePickerHandler.MapTime(handler, picker);

        // Assert
        act.Should().NotThrow("MapTime should safely handle null PlatformView");
    }

    [Fact]
    public void MapMinimumTime_WithNullPlatformView_ShouldNotThrow()
    {
        // Arrange
        var handler = new NativeTimePickerHandler();
        var picker = new NativeTimePicker { MinimumTime = new TimeOnly(9, 0) };

        // Act - Bug #8: Verify null check prevents exceptions
        Action act = () => NativeTimePickerHandler.MapMinimumTime(handler, picker);

        // Assert
        act.Should().NotThrow("MapMinimumTime should safely handle null PlatformView");
    }

    [Fact]
    public void MapMaximumTime_WithNullPlatformView_ShouldNotThrow()
    {
        // Arrange
        var handler = new NativeTimePickerHandler();
        var picker = new NativeTimePicker { MaximumTime = new TimeOnly(17, 0) };

        // Act - Bug #8: Verify null check prevents exceptions
        Action act = () => NativeTimePickerHandler.MapMaximumTime(handler, picker);

        // Assert
        act.Should().NotThrow("MapMaximumTime should safely handle null PlatformView");
    }
}
