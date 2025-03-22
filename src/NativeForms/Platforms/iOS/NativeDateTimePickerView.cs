using Microsoft.Maui.Platform;
using System.Diagnostics;
using UIKit;

namespace NativeForms.Platforms.iOS;

public sealed class NativeDateTimePickerView : UIDatePicker
{
    public NativeDateTimePickerView(NativeDateTimePicker virtualView)
    {
        Mode = UIDatePickerMode.DateAndTime;
        PreferredDatePickerStyle = UIDatePickerStyle.Compact;
        ValueChanged += OnDateChanged;
        VirtualView = virtualView;
    }

    private void OnDateChanged(object? sender, EventArgs e)
    {
        Debug.WriteLine("Date changed");
        VirtualView.DateTime = Date.ToDateTime();
    }

    public NativeDateTimePicker VirtualView { get; set; }

    public void UpdateDate(DateTimeOffset dateTime)
    {
        Debug.WriteLine("Update date");
        SetDate(dateTime.DateTime.ToNSDate(), true);
    }

    public void UpdateMinimumDate(DateTimeOffset dateTime)
    {
        MinimumDate = dateTime.DateTime.ToNSDate();
    }

    public void UpdateMaximumDate(DateTimeOffset dateTime)
    {
        MaximumDate = dateTime.DateTime.ToNSDate();
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
