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
        var components = new NSDateComponents { Hour = time.Hour, Minute = time.Minute, Second = time.Second, };
        Date = NSCalendar.CurrentCalendar.DateFromComponents(components);
    }

    public void UpdateMinimumTime(TimeOnly time)
    {
        var components = new NSDateComponents { Hour = time.Hour, Minute = time.Minute, Second = time.Second, };
        MinimumDate = NSCalendar.CurrentCalendar.DateFromComponents(components);
    }

    public void UpdateMaximumTime(TimeOnly time)
    {
        var components = new NSDateComponents { Hour = time.Hour, Minute = time.Minute, Second = time.Second, };
        MaximumDate = NSCalendar.CurrentCalendar.DateFromComponents(components);
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
