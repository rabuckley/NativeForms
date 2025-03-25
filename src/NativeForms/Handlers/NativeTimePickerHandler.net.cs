using Microsoft.Maui.Handlers;

namespace NativeForms.Handlers;

public partial class NativeTimePickerHandler : ViewHandler<NativeTimePicker, object>
{
    protected override object CreatePlatformView() => throw new NotSupportedException();

    public static void MapTime(NativeTimePickerHandler handler, object view)
    {
    }

    public static void MapMaximumTime(NativeTimePickerHandler handler, object view)
    {
    }

    public static void MapMinimumTime(NativeTimePickerHandler handler, object view)
    {
    }
}
