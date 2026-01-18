using Foundation;
using UIKit;

namespace NativeForms.Platforms.iOS;

public sealed class NativeTimePickerView : UIDatePicker
{
    private const NSCalendarUnit TimeUnits = NSCalendarUnit.Hour | NSCalendarUnit.Minute | NSCalendarUnit.Second;

    private readonly NativeTimePicker _virtualView;

    public NativeTimePickerView(NativeTimePicker virtualView)
    {
        ArgumentNullException.ThrowIfNull(virtualView);

        _virtualView = virtualView;
        Mode = UIDatePickerMode.Time;
        PreferredDatePickerStyle = UIDatePickerStyle.Compact;
        ValueChanged += OnDateChanged;
    }

    public void UpdateTime(TimeOnly time)
    {
        var referenceDate = NSDate.Now;
        var calendar = NSCalendar.CurrentCalendar;
        var components = calendar.Components(NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, referenceDate);
        components.Hour = time.Hour;
        components.Minute = time.Minute;
        components.Second = time.Second;
        Date = calendar.DateFromComponents(components) ?? NSDate.Now;
    }

    public void UpdateMinimumTime(TimeOnly time)
    {
        var referenceDate = NSDate.Now;
        var calendar = NSCalendar.CurrentCalendar;
        var components = calendar.Components(NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, referenceDate);
        components.Hour = time.Hour;
        components.Minute = time.Minute;
        components.Second = time.Second;
        MinimumDate = calendar.DateFromComponents(components) ?? NSDate.DistantPast;
    }

    public void UpdateMaximumTime(TimeOnly time)
    {
        var referenceDate = NSDate.Now;
        var calendar = NSCalendar.CurrentCalendar;
        var components = calendar.Components(NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, referenceDate);
        components.Hour = time.Hour;
        components.Minute = time.Minute;
        components.Second = time.Second;
        MaximumDate = calendar.DateFromComponents(components) ?? NSDate.DistantFuture;
    }

    private void OnDateChanged(object? sender, EventArgs e)
    {
        NSDateComponents components = NSCalendar.CurrentCalendar.Components(TimeUnits, Date);
        _virtualView.Time = new TimeOnly((int)components.Hour, (int)components.Minute, (int)components.Second);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            ValueChanged -= OnDateChanged;
        }

        base.Dispose(disposing);
    }
}
