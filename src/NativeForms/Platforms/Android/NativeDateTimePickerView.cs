using Android.Content;
using Android.Widget;
using Google.Android.Material.DatePicker;
using Google.Android.Material.TimePicker;
using Microsoft.Maui.Platform;
using System.Globalization;

namespace NativeForms.Platforms.Android;

public sealed partial class NativeDateTimePickerView : LinearLayout, IDateTimeUpdatable, ITimeOnlyUpdatable
{
    private readonly Context _context;
    private readonly NativeDateTimePicker _virtualView;
    private readonly EditText _dateEditText;
    private readonly EditText _timeEditText;

    public NativeDateTimePickerView(Context context, NativeDateTimePicker virtualView) : base(context)
    {
        _context = context;
        _virtualView = virtualView;
        DividerPadding = 10;

        var dateText = new EditText(context);
        dateText.Focusable = false;
        dateText.Clickable = true;
        dateText.Click += ShowDatePickerDialog;
        _dateEditText = dateText;

        var timeText = new EditText(context);
        timeText.Focusable = false;
        timeText.Clickable = true;
        timeText.Click += ShowTimePickerDialog;
        _timeEditText = timeText;

        AddView(dateText);
        AddView(timeText);
    }

    private void ShowDatePickerDialog(object? sender, EventArgs e)
    {
        DateTimeOffset dto = _virtualView.DateTime;
        var datePicker = MaterialDatePicker.Builder
            .DatePicker()
            .SetInputMode(MaterialDatePicker.InputModeCalendar)
            .SetSelection(dto.ToUnixTimeMilliseconds())
            .Build();

        var listener = MaterialPickerOnPositiveButtonClickListener.Create(this);
        datePicker.AddOnPositiveButtonClickListener(listener);

        var manager = _context.GetFragmentManager()!;
        datePicker.Show(manager, "DatePicker");
    }

    private void ShowTimePickerDialog(object? sender, EventArgs e)
    {
        var dialog = new MaterialTimePicker.Builder()
            .SetInputMode(MaterialTimePicker.InputModeClock)
            .SetHour(_virtualView.DateTime.Hour)
            .SetMinute(_virtualView.DateTime.Minute)
            .Build();

        var listener = TimePickerOnClickListener.Create(dialog, this);
        dialog.AddOnPositiveButtonClickListener(listener);

        var manager = _context.GetFragmentManager()!;
        dialog.Show(manager, "TimePicker");
    }

    public void UpdateDate(DateTime date)
    {
        _virtualView.DateTime = date;
        _dateEditText.Text = date.ToString("d", CultureInfo.CurrentCulture);
        _timeEditText.Text = date.ToString("t", CultureInfo.CurrentCulture);
    }

    public void UpdateTime(TimeOnly value)
    {
        var current = _virtualView.DateTime;
        _virtualView.DateTime = new DateTime(DateOnly.FromDateTime(current), value);
    }

    public void UpdateMaximumDate(DateTime viewMaximumDateTime)
    {
    }

    public void UpdateMinimumDate(DateTime viewMinimumDateTime)
    {
    }
}
