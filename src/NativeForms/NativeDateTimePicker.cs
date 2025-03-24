namespace NativeForms;

public sealed partial class NativeDateTimePicker : View
{
    public static readonly BindableProperty DateTimeProperty = BindableProperty.Create(
        nameof(DateTime),
        typeof(DateTime),
        typeof(NativeDateTimePicker),
        System.DateTime.Now,
        defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty MaximumDateTimeProperty = BindableProperty.Create(
        nameof(MaximumDateTime),
        typeof(DateTime),
        typeof(NativeDateTimePicker),
        System.DateTime.MaxValue,
        defaultBindingMode: BindingMode.OneWay);

    public static readonly BindableProperty MinimumDateTimeProperty = BindableProperty.Create(
        nameof(MinimumDateTime),
        typeof(DateTime),
        typeof(NativeDateTimePicker),
        System.DateTime.MinValue,
        defaultBindingMode: BindingMode.OneWay);

    public DateTime DateTime
    {
        get => (DateTime)GetValue(DateTimeProperty);
        set => SetValue(DateTimeProperty, value);
    }

    public DateTime MaximumDateTime
    {
        get => (DateTime)GetValue(MaximumDateTimeProperty);
        set => SetValue(MaximumDateTimeProperty, value);
    }

    public DateTime MinimumDateTime
    {
        get => (DateTime)GetValue(MinimumDateTimeProperty);
        set => SetValue(MinimumDateTimeProperty, value);
    }
}
