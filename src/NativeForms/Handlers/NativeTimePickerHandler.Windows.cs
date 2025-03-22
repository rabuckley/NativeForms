using Microsoft.Maui.Handlers;
using Microsoft.UI.Xaml.Controls;
using TimePicker = Microsoft.UI.Xaml.Controls.TimePicker;

namespace NativeForms.Handlers;

public partial class NativeTimePickerHandler : ViewHandler<NativeTimePicker, TimePicker>
{
    protected override TimePicker CreatePlatformView() => new();

    protected override void ConnectHandler(TimePicker platformView)
    {
        platformView.TimeChanged += OnTimeChanged;
        base.ConnectHandler(platformView);
    }

    protected override void DisconnectHandler(TimePicker platformView)
    {
        platformView.TimeChanged -= OnTimeChanged;
        base.DisconnectHandler(platformView);
    }

    private void OnTimeChanged(object? sender, TimePickerValueChangedEventArgs e)
    {
        VirtualView.Time = TimeOnly.FromTimeSpan(e.NewTime);
    }

    public static void MapTime(NativeTimePickerHandler handler, NativeTimePicker view)
    {
        handler.PlatformView.Time = view.Time.ToTimeSpan();
    }

    public static void MapMaximumTime(NativeTimePickerHandler handler, NativeTimePicker view)
    {
    }

    public static void MapMinimumTime(NativeTimePickerHandler handler, NativeTimePicker view)
    {
    }
}
