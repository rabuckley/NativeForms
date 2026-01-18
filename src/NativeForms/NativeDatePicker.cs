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
        defaultBindingMode: BindingMode.OneWay,
        propertyChanged: OnMinimumDateChanged);

    private static void OnMinimumDateChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not NativeDatePicker picker || newValue is not DateOnly minimumDate)
            return;

        if (minimumDate > picker.MaximumDate)
        {
            picker.MaximumDate = minimumDate;
        }

        if (picker.Date < minimumDate)
        {
            picker.Date = minimumDate;
        }
    }

    public static readonly BindableProperty MaximumDateProperty = BindableProperty.Create(
        nameof(MaximumDate),
        typeof(DateOnly),
        typeof(NativeDatePicker),
        DateOnly.MaxValue,
        defaultBindingMode: BindingMode.OneWay,
        propertyChanged: OnMaximumDateChanged);

    private static void OnMaximumDateChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not NativeDatePicker picker || newValue is not DateOnly maximumDate)
            return;

        if (maximumDate < picker.MinimumDate)
        {
            picker.MinimumDate = maximumDate;
        }

        if (picker.Date > maximumDate)
        {
            picker.Date = maximumDate;
        }
    }

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
