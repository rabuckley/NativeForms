using Microsoft.Maui.Handlers;

namespace NativeForms.Handlers;

public partial class NativeDatePickerHandler : ViewHandler<NativeDatePicker, object>
{
    protected override object CreatePlatformView() => throw new NotSupportedException();

    public static void MapDate(NativeDatePickerHandler handler, object view)
    {
    }

    public static void MapMaximumDate(NativeDatePickerHandler handler, object view)
    {
    }

    public static void MapMinimumDate(NativeDatePickerHandler handler, object view)
    {
    }
}
