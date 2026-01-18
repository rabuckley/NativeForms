using Microsoft.Maui.Handlers;
using NativeForms.Platforms.Android;

namespace NativeForms.Handlers;

public partial class NativeDateTimePickerHandler : ViewHandler<NativeDateTimePicker, NativeDateTimePickerView>
{
    protected override NativeDateTimePickerView CreatePlatformView() => new(Context, VirtualView);

    protected override void DisconnectHandler(NativeDateTimePickerView platformView)
    {
        platformView.Dispose();
        base.DisconnectHandler(platformView);
    }

    public static void MapDate(NativeDateTimePickerHandler handler, NativeDateTimePicker view)
    {
        if (handler.PlatformView is null)
            return;

        handler.PlatformView.UpdateDate(view.DateTime);
    }

    public static void MapMaximumDate(NativeDateTimePickerHandler handler, NativeDateTimePicker view)
    {
        if (handler.PlatformView is null)
            return;

        handler.PlatformView.UpdateMaximumDate(view.MaximumDateTime);
    }

    public static void MapMinimumDate(NativeDateTimePickerHandler handler, NativeDateTimePicker view)
    {
        if (handler.PlatformView is null)
            return;

        handler.PlatformView.UpdateMinimumDate(view.MinimumDateTime);
    }
}
