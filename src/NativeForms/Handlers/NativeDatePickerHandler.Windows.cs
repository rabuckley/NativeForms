using Microsoft.Maui.Handlers;
using Microsoft.UI.Xaml.Controls;

namespace NativeForms.Handlers;

public sealed partial class NativeDatePickerHandler : ViewHandler<NativeDatePicker, CalendarDatePicker>
{
    protected override CalendarDatePicker CreatePlatformView() => new();

    protected override void ConnectHandler(CalendarDatePicker platformView)
    {
        platformView.DateChanged += OnDateChanged;
        base.ConnectHandler(platformView);
    }

    protected override void DisconnectHandler(CalendarDatePicker platformView)
    {
        platformView.DateChanged -= OnDateChanged;
        base.DisconnectHandler(platformView);
    }

    private void OnDateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
    {
        if (args.NewDate is not DateTimeOffset newDate)
        {
            return;
        }

        VirtualView.Date = DateOnly.FromDateTime(newDate.DateTime);
    }

    public static void MapDate(NativeDatePickerHandler handler, NativeDatePicker view)
    {
        if (handler.PlatformView is null)
            return;

        handler.PlatformView.Date = view.Date.ToDateTime(TimeOnly.MinValue);
    }

    public static void MapMaximumDate(NativeDatePickerHandler handler, NativeDatePicker view)
    {
        if (handler.PlatformView is null)
            return;

        handler.PlatformView.MaxDate = view.MaximumDate.ToDateTime(TimeOnly.MaxValue);
    }

    public static void MapMinimumDate(NativeDatePickerHandler handler, NativeDatePicker view)
    {
        if (handler.PlatformView is null)
            return;

        handler.PlatformView.MinDate = view.MinimumDate.ToDateTime(TimeOnly.MinValue);
    }
}
