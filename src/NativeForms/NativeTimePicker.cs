namespace NativeForms;

public sealed partial class NativeTimePicker : View
{
    public static readonly BindableProperty TimeProperty = BindableProperty.Create(
        nameof(Time),
        typeof(TimeOnly),
        typeof(NativeTimePicker),
        TimeOnly.MinValue,
        defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty MinimumTimeProperty = BindableProperty.Create(
        nameof(MinimumTime),
        typeof(TimeOnly),
        typeof(NativeTimePicker),
        TimeOnly.MinValue,
        defaultBindingMode: BindingMode.OneWay,
        propertyChanged: OnMinimumTimeChanged);

    private static void OnMinimumTimeChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not NativeTimePicker picker || newValue is not TimeOnly minimumTime)
            return;

        if (minimumTime > picker.MaximumTime)
        {
            picker.MaximumTime = minimumTime;
        }

        if (picker.Time < minimumTime)
        {
            picker.Time = minimumTime;
        }
    }

    public static readonly BindableProperty MaximumTimeProperty = BindableProperty.Create(
        nameof(MaximumTime),
        typeof(TimeOnly),
        typeof(NativeTimePicker),
        TimeOnly.MaxValue,
        defaultBindingMode: BindingMode.OneWay,
        propertyChanged: OnMaximumTimeChanged);

    private static void OnMaximumTimeChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not NativeTimePicker picker || newValue is not TimeOnly maximumTime)
            return;

        if (maximumTime < picker.MinimumTime)
        {
            picker.MinimumTime = maximumTime;
        }

        if (picker.Time > maximumTime)
        {
            picker.Time = maximumTime;
        }
    }

    public TimeOnly Time
    {
        get => (TimeOnly)GetValue(TimeProperty);
        set => SetValue(TimeProperty, value);
    }

    public TimeOnly MinimumTime
    {
        get => (TimeOnly)GetValue(MinimumTimeProperty);
        set => SetValue(MinimumTimeProperty, value);
    }

    public TimeOnly MaximumTime
    {
        get => (TimeOnly)GetValue(MaximumTimeProperty);
        set => SetValue(MaximumTimeProperty, value);
    }
}
