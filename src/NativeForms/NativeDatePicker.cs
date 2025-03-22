namespace NativeForms;

public sealed partial class NativeDatePicker : View
{
    public static readonly BindableProperty DateProperty = BindableProperty.Create(
        nameof(Date),
        typeof(DateOnly),
        typeof(NativeDatePicker),
        DateOnly.MinValue,
        defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty MinimumDateProperty = BindableProperty.Create(
        nameof(MinimumDate),
        typeof(DateOnly),
        typeof(NativeDatePicker),
        DateOnly.MinValue,
        defaultBindingMode: BindingMode.OneWay);

    public static readonly BindableProperty MaximumDateProperty = BindableProperty.Create(
        nameof(MaximumDate),
        typeof(DateOnly),
        typeof(NativeDatePicker),
        DateOnly.MaxValue,
        defaultBindingMode: BindingMode.OneWay);

    public DateOnly Date
    {
        get => (DateOnly)GetValue(DateProperty);
        set => SetValue(DateProperty, value);
    }

    public DateOnly MinimumDate
    {
        get => (DateOnly)GetValue(MinimumDateProperty);
        set => SetValue(MinimumDateProperty, value);
    }

    public DateOnly MaximumDate
    {
        get => (DateOnly)GetValue(MaximumDateProperty);
        set => SetValue(MaximumDateProperty, value);
    }
}
