using Android.Content;
using Android.Widget;
using Google.Android.Material.DatePicker;
using Microsoft.Maui.Platform;
using System.Globalization;
using Calendar = Java.Util.Calendar;

namespace NativeForms.Platforms.Android;

public sealed class NativeDatePickerView : LinearLayout, IDateTimeOffsetUpdatable
{
    private readonly Context _context;
    private readonly NativeDatePicker _virtualView;
    private readonly EditText _dateEditText;

    public NativeDatePickerView(NativeDatePicker virtualView, Context context) : base(context)
    {
        _context = context;
        _virtualView = virtualView;

        _dateEditText = new EditText(context)
        {
            Focusable = false,
            Clickable = true
        };

        _dateEditText.Click += ShowDatePickerDialog;

        AddView(_dateEditText);
    }

    private void ShowDatePickerDialog(object? sender, EventArgs e)
    {
        DateTimeOffset minDate = _virtualView.MinimumDate.ToDateTime(TimeOnly.MinValue);
        DateTimeOffset maxDate = _virtualView.MaximumDate.ToDateTime(TimeOnly.MinValue);

        var validator = CompositeDateValidator.AllOf([
            DateValidatorPointForward.From(minDate.ToUnixTimeMilliseconds()),
            DateValidatorPointBackward.Before(maxDate.ToUnixTimeMilliseconds())
        ]);

        var constraints = new CalendarConstraints.Builder()
            .SetValidator(validator)
            .Build();

        DateTimeOffset offset = _virtualView.Date.ToDateTime(TimeOnly.MinValue);

        var datePicker = MaterialDatePicker.Builder
            .DatePicker()
            .SetInputMode(MaterialDatePicker.InputModeCalendar)
            .SetCalendarConstraints(constraints)
            .SetSelection(offset.ToUnixTimeMilliseconds())
            .Build();

        var listener = MaterialPickerOnPositiveButtonClickListener.Create(this);
        datePicker.AddOnPositiveButtonClickListener(listener);

        var manager = _context.GetFragmentManager()!;
        datePicker.Show(manager, "DatePicker");
    }

    public void UpdateDate(DateTimeOffset value)
    {
        _virtualView.Date = DateOnly.FromDateTime(value.DateTime);
        UpdateDate(_virtualView.Date);
    }

    public void UpdateDate(DateOnly date)
    {
        _dateEditText.Text = date.ToString("d", CultureInfo.CurrentCulture);
    }

    public void UpdateMaximumDate(DateOnly value)
    {
        // Nothing
    }

    public void UpdateMinimumDate(DateOnly value)
    {
        // Nothing
    }
}
