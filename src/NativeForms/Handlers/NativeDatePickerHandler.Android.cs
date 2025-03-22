using Microsoft.Maui.Handlers;
using NativeForms.Platforms.Android;

namespace NativeForms.Handlers;

public partial class NativeDatePickerHandler : ViewHandler<NativeDatePicker, NativeDatePickerView>
{
    protected override NativeDatePickerView CreatePlatformView() => new(VirtualView, Context);

    protected override void DisconnectHandler(NativeDatePickerView platformView)
    {
        platformView.Dispose();
        base.DisconnectHandler(platformView);
    }

    public static void MapDate(NativeDatePickerHandler handler, NativeDatePicker view)
    {
        handler.PlatformView.UpdateDate(view.Date);
    }

    public static void MapMaximumDate(NativeDatePickerHandler handler, NativeDatePicker view)
    {
        handler.PlatformView.UpdateMaximumDate(view.MaximumDate);
    }

    public static void MapMinimumDate(NativeDatePickerHandler handler, NativeDatePicker view)
    {
        handler.PlatformView.UpdateMinimumDate(view.MinimumDate);
    }
}
