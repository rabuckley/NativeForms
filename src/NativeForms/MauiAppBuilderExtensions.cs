using NativeForms.Handlers;

namespace NativeForms;

public static class MauiAppBuilderExtensions
{
    public static MauiAppBuilder UseNativeForms(this MauiAppBuilder builder)
    {
        return builder.ConfigureMauiHandlers(handlers =>
        {
            handlers.AddHandler<NativeDateTimePicker, NativeDateTimePickerHandler>();
            handlers.AddHandler<NativeDatePicker, NativeDatePickerHandler>();
            handlers.AddHandler<NativeTimePicker, NativeTimePickerHandler>();

#if IOS || MACCATALYST
            handlers.AddHandler<Picker, NativePickerHandler>();
#endif
        });
    }
}
