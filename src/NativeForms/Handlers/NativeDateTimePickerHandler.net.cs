using Microsoft.Maui.Handlers;

namespace NativeForms.Handlers;

public partial class NativeDateTimePickerHandler : ViewHandler<NativeDateTimePicker, object>
{
    protected override object CreatePlatformView() => throw new NotSupportedException();

    public static void MapDate(NativeDateTimePickerHandler handler, object view)
    {
    }

    public static void MapMaximumDate(NativeDateTimePickerHandler handler, object view)
    {
    }

    public static void MapMinimumDate(NativeDateTimePickerHandler handler, object view)
    {
    }
}
