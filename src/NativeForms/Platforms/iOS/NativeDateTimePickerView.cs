using Microsoft.Maui.Platform;
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
        VirtualView.DateTime = Date.ToDateTime();
    }

    public NativeDateTimePicker VirtualView { get; set; }

    public void UpdateDate(DateTime dateTime)
    {
        SetDate(dateTime.ToNSDate(), true);
    }

    public void UpdateMinimumDate(DateTime dateTime)
    {
        MinimumDate = dateTime.ToNSDate();
    }

    public void UpdateMaximumDate(DateTime dateTime)
    {
        MaximumDate = dateTime.ToNSDate();
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
