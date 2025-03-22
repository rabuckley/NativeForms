
using Microsoft.UI.Xaml.Controls;
using DatePicker = Microsoft.UI.Xaml.Controls.DatePicker;
using Grid = Microsoft.UI.Xaml.Controls.Grid;
using TimePicker = Microsoft.UI.Xaml.Controls.TimePicker;

namespace NativeForms.Platforms.Windows;

public sealed partial class NativeDateTimePickerView : Grid, IDisposable
{
    private readonly NativeDateTimePicker _virtualView;
    private readonly DatePicker _datePicker;
    private readonly TimePicker _timePicker;

    public NativeDateTimePickerView(NativeDateTimePicker virtualView)
    {
        _virtualView = virtualView;

        _datePicker = new DatePicker();

        _datePicker.DateChanged += OnDatePickerDateChanged;

        _timePicker = new TimePicker();

        _timePicker.TimeChanged += OnTimePickerTimeChanged;

        RowSpacing = 4;

        RowDefinitions.Add(new());
        RowDefinitions.Add(new());

        SetRow(_datePicker, 0);
        Children.Add(_datePicker);

        SetRow(_timePicker, 1);
        Children.Add(_timePicker);
    }

    private void OnDatePickerDateChanged(object? sender, DatePickerValueChangedEventArgs e)
    {
        _virtualView.DateTime = e.NewDate;
    }

    private void OnTimePickerTimeChanged(object? sender, TimePickerValueChangedEventArgs e)
    {
        _virtualView.DateTime = _virtualView.DateTime.Date + e.NewTime;
    }

    public void UpdateDate(DateTimeOffset date)
    {
        _datePicker.Date = date.Date;
        _timePicker.Time = date.TimeOfDay;
    }

    public void UpdateMaximumDate(DateTimeOffset maximumDate)
    {
        _datePicker.MaxYear = maximumDate;
    }

    public void UpdateMinimumDate(DateTimeOffset minimumDate)
    {
        _datePicker.MinYear = minimumDate;
    }

    public void Dispose()
    {
        _datePicker.DateChanged -= OnDatePickerDateChanged;
        _timePicker.TimeChanged -= OnTimePickerTimeChanged;
    }
}
