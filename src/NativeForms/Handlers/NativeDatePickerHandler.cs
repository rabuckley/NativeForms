namespace NativeForms.Handlers;

public partial class NativeDatePickerHandler
{
    public static readonly IPropertyMapper<NativeDatePicker, NativeDatePickerHandler> PropertyMapper =
        new PropertyMapper<NativeDatePicker, NativeDatePickerHandler>(ViewMapper)
        {
            [nameof(NativeDatePicker.Date)] = MapDate,
            [nameof(NativeDatePicker.MaximumDate)] = MapMaximumDate,
            [nameof(NativeDatePicker.MinimumDate)] = MapMinimumDate,
        };

    public NativeDatePickerHandler() : base(PropertyMapper)
    {
    }
}
