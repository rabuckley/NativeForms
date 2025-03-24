namespace NativeForms.Platforms.Android;

internal static class MaterialPickerOnPositiveButtonClickListener
{
    public static MaterialPickerOnPositiveButtonClickListener<T> Create<T>(T view)
        where T : IDateTimeUpdatable
    {
        return new MaterialPickerOnPositiveButtonClickListener<T>(view);
    }
}
