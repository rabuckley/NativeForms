namespace NativeForms.Handlers;

public partial class NativeDateTimePickerHandler
{
    public readonly static IPropertyMapper<NativeDateTimePicker, NativeDateTimePickerHandler> PropertyMapper =
        new PropertyMapper<NativeDateTimePicker, NativeDateTimePickerHandler>(ViewMapper)
        {
            [nameof(NativeDateTimePicker.DateTime)] = MapDate,
            [nameof(NativeDateTimePicker.MaximumDateTime)] = MapMaximumDate,
            [nameof(NativeDateTimePicker.MinimumDateTime)] = MapMinimumDate,
        };

    public NativeDateTimePickerHandler() : base(PropertyMapper)
    {
    }
}
