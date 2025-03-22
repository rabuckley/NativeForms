namespace NativeForms;

public sealed partial class NativeDateTimePicker : View
{
    public static readonly BindableProperty DateTimeProperty = BindableProperty.Create(
        nameof(DateTime),
        typeof(DateTimeOffset),
        typeof(NativeDateTimePicker),
        DateTimeOffset.MinValue,
        defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty MaximumDateTimeProperty = BindableProperty.Create(
        nameof(MaximumDateTime),
        typeof(DateTimeOffset),
        typeof(NativeDateTimePicker),
        DateTimeOffset.MaxValue,
        defaultBindingMode: BindingMode.OneWay);

    public static readonly BindableProperty MinimumDateTimeProperty = BindableProperty.Create(
        nameof(MinimumDateTime),
        typeof(DateTimeOffset),
        typeof(NativeDateTimePicker),
        DateTimeOffset.MinValue,
        defaultBindingMode: BindingMode.OneWay);

    public DateTimeOffset DateTime
    {
        get => (DateTimeOffset)GetValue(DateTimeProperty);
        set => SetValue(DateTimeProperty, value);
    }

    public DateTimeOffset MaximumDateTime
    {
        get => (DateTimeOffset)GetValue(MaximumDateTimeProperty);
        set => SetValue(MaximumDateTimeProperty, value);
    }

    public DateTimeOffset MinimumDateTime
    {
        get => (DateTimeOffset)GetValue(MinimumDateTimeProperty);
        set => SetValue(MinimumDateTimeProperty, value);
    }
}
