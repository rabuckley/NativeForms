using Google.Android.Material.TimePicker;
using System.Diagnostics;
using View = Android.Views.View;

namespace NativeForms.Platforms.Android;

internal static class TimePickerOnClickListener
{
    public static TimePickerOnClickListener<T> Create<T>(MaterialTimePicker picker, T view)
        where T : ITimeOnlyUpdatable
    {
        return new TimePickerOnClickListener<T>(picker, view);
    }
}

internal sealed class TimePickerOnClickListener<T> : Java.Lang.Object, View.IOnClickListener
    where T : ITimeOnlyUpdatable
{
    private readonly MaterialTimePicker _picker;
    private readonly T _view;

    public TimePickerOnClickListener(MaterialTimePicker picker, T view)
    {
        _picker = picker;
        _view = view;
    }

    public void OnClick(View? v)
    {
        var time = new TimeOnly(_picker.Hour, _picker.Minute);
        _view.UpdateTime(time);
    }
}
