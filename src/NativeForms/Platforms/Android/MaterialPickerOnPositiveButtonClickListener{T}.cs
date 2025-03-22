using Google.Android.Material.DatePicker;

namespace NativeForms.Platforms.Android;

internal sealed class MaterialPickerOnPositiveButtonClickListener<T> : Java.Lang.Object,
    IMaterialPickerOnPositiveButtonClickListener
    where T : IDateTimeOffsetUpdatable
{
    private readonly T _view;

    public MaterialPickerOnPositiveButtonClickListener(T view)
    {
        _view = view;
    }

    public void OnPositiveButtonClick(Java.Lang.Object? selection)
    {
        if (selection is null)
        {
            return;
        }

        var dto = DateTimeOffset.FromUnixTimeMilliseconds((long)selection);
        _view.UpdateDate(dto);
    }
}
