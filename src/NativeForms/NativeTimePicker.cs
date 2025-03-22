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
        defaultBindingMode: BindingMode.OneWay);

    public static readonly BindableProperty MaximumTimeProperty = BindableProperty.Create(
        nameof(MaximumTime),
        typeof(TimeOnly),
        typeof(NativeTimePicker),
        TimeOnly.MaxValue,
        defaultBindingMode: BindingMode.OneWay);

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
