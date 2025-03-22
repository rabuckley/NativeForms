namespace NativeForms.Handlers;

public partial class NativeTimePickerHandler
{
    public static readonly IPropertyMapper<NativeTimePicker, NativeTimePickerHandler> PropertyMapper =
        new PropertyMapper<NativeTimePicker, NativeTimePickerHandler>(ViewMapper)
        {
            [nameof(NativeTimePicker.Time)] = MapTime,
            [nameof(NativeTimePicker.MaximumTime)] = MapMaximumTime,
            [nameof(NativeTimePicker.MinimumTime)] = MapMinimumTime,
        };

    public NativeTimePickerHandler() : base(PropertyMapper)
    {
    }
}
