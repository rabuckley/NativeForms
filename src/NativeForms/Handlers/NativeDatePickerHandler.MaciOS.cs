using Microsoft.Maui.Handlers;
using NativeForms.Platforms.iOS;

namespace NativeForms.Handlers;

public partial class NativeDatePickerHandler : ViewHandler<NativeDatePicker, NativeDatePickerView>
{
    protected override NativeDatePickerView CreatePlatformView() => new(VirtualView);

    protected override void DisconnectHandler(NativeDatePickerView platformView)
    {
        platformView.Dispose();
        base.DisconnectHandler(platformView);
    }

    public static void MapDate(NativeDatePickerHandler handler, NativeDatePicker view)
    {
        if (handler.PlatformView is null)
            return;

        handler.PlatformView.UpdateDate(view.Date);
    }

    public static void MapMaximumDate(NativeDatePickerHandler handler, NativeDatePicker view)
    {
        if (handler.PlatformView is null)
            return;

        handler.PlatformView.UpdateMaximumDate(view.MaximumDate);
    }

    public static void MapMinimumDate(NativeDatePickerHandler handler, NativeDatePicker view)
    {
        if (handler.PlatformView is null)
            return;

        handler.PlatformView.UpdateMinimumDate(view.MinimumDate);
    }
}
