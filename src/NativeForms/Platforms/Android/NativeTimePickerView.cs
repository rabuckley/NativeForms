using Android.Content;
using Android.Widget;
using Google.Android.Material.TimePicker;
using Microsoft.Maui.Platform;
using System.Globalization;

namespace NativeForms.Platforms.Android;

public sealed class NativeTimePickerView : LinearLayout, ITimeOnlyUpdatable
{
    private readonly Context _context;
    private readonly NativeTimePicker _virtualView;
    private readonly EditText _timeEditText;

    public NativeTimePickerView(NativeTimePicker virtualView, Context context) : base(context)
    {
        _context = context;
        _virtualView = virtualView;

        var timeText = new EditText(context)
        {
            Focusable = false,
            Clickable = true
        };

        timeText.Click += ShowTimePickerDialog;
        _timeEditText = timeText;

        AddView(timeText);
    }


    private void ShowTimePickerDialog(object? sender, EventArgs e)
    {
        var picker = new MaterialTimePicker.Builder()
            .SetTimeFormat(TimeFormat.Clock12h)
            .SetInputMode(MaterialTimePicker.InputModeClock)
            .SetHour(_virtualView.Time.Hour)
            .SetMinute(_virtualView.Time.Minute)
            .Build();

        var listener = TimePickerOnClickListener.Create(picker, this);
        picker.AddOnPositiveButtonClickListener(listener);

        var manager = _context.GetFragmentManager()!;
        picker.Show(manager, "TimePicker");
    }

    public void UpdateTime(TimeOnly time)
    {
        _timeEditText.Text = time.ToString("t", CultureInfo.CurrentCulture);
    }

    public void UpdateMaximumTime(TimeOnly viewMaximumTime)
    {
    }

    public void UpdateMinimumTime(TimeOnly viewMinimumTime)
    {
    }
}
