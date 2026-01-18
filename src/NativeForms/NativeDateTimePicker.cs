namespace NativeForms;

public sealed partial class NativeDateTimePicker : View
{
    public static readonly BindableProperty DateTimeProperty = BindableProperty.Create(
        nameof(DateTime),
        typeof(DateTime),
        typeof(NativeDateTimePicker),
        default(DateTime),
        defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty MaximumDateTimeProperty = BindableProperty.Create(
        nameof(MaximumDateTime),
        typeof(DateTime),
        typeof(NativeDateTimePicker),
        DateTime.MaxValue,
        defaultBindingMode: BindingMode.OneWay,
        propertyChanged: OnMaximumDateTimeChanged);

    private static void OnMaximumDateTimeChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not NativeDateTimePicker picker || newValue is not DateTime maximumDateTime)
            return;

        if (maximumDateTime < picker.MinimumDateTime)
        {
            picker.MinimumDateTime = maximumDateTime;
        }

        if (picker.DateTime > maximumDateTime)
        {
            picker.DateTime = maximumDateTime;
        }
    }

    public static readonly BindableProperty MinimumDateTimeProperty = BindableProperty.Create(
        nameof(MinimumDateTime),
        typeof(DateTime),
        typeof(NativeDateTimePicker),
        DateTime.MinValue,
        defaultBindingMode: BindingMode.OneWay,
        propertyChanged: OnMinimumDateTimeChanged);

    private static void OnMinimumDateTimeChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not NativeDateTimePicker picker || newValue is not DateTime minimumDateTime)
            return;

        if (minimumDateTime > picker.MaximumDateTime)
        {
            picker.MaximumDateTime = minimumDateTime;
        }

        if (picker.DateTime < minimumDateTime)
        {
            picker.DateTime = minimumDateTime;
        }
    }

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
