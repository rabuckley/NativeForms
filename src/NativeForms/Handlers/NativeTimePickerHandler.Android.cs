using Microsoft.Maui.Handlers;
using NativeForms.Platforms.Android;

namespace NativeForms.Handlers;

public partial class NativeTimePickerHandler : ViewHandler<NativeTimePicker, NativeTimePickerView>
{
    protected override NativeTimePickerView CreatePlatformView() => new(VirtualView, Context);

    protected override void DisconnectHandler(NativeTimePickerView platformView)
    {
        platformView.Dispose();
        base.DisconnectHandler(platformView);
    }

    public static void MapTime(NativeTimePickerHandler handler, NativeTimePicker view)
    {
        handler.PlatformView.UpdateTime(view.Time);
    }

    public static void MapMaximumTime(NativeTimePickerHandler handler, NativeTimePicker view)
    {
        handler.PlatformView.UpdateMaximumTime(view.MaximumTime);
    }

    public static void MapMinimumTime(NativeTimePickerHandler handler, NativeTimePicker view)
    {
        handler.PlatformView.UpdateMinimumTime(view.MinimumTime);
    }
}
