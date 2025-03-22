using Microsoft.Maui.Platform;
using UIKit;

namespace NativeForms.Platforms.iOS;

public sealed class NativeDatePickerView : UIDatePicker
{
    public NativeDatePickerView(NativeDatePicker virtualView)
    {
        Mode = UIDatePickerMode.Date;
        PreferredDatePickerStyle = UIDatePickerStyle.Compact;
        ValueChanged += OnDateChanged;
        VirtualView = virtualView;
    }

    private void OnDateChanged(object? sender, EventArgs e)
    {
        VirtualView.Date = DateOnly.FromDateTime(Date.ToDateTime());
    }

    public NativeDatePicker VirtualView { get; set; }

    public void UpdateDate(DateOnly date)
    {
        Date = date.ToDateTime(TimeOnly.MinValue).ToNSDate();
    }

    public void UpdateMaximumDate(DateOnly date)
    {
        MaximumDate = date.ToDateTime(TimeOnly.MinValue).ToNSDate();
    }

    public void UpdateMinimumDate(DateOnly date)
    {
        MinimumDate = date.ToDateTime(TimeOnly.MinValue).ToNSDate();
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
