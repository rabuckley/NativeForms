using Google.Android.Material.DatePicker;

namespace NativeForms.Platforms.Android;

internal sealed class MaterialPickerOnPositiveButtonClickListener<T> : Java.Lang.Object,
    IMaterialPickerOnPositiveButtonClickListener
    where T : IDateTimeUpdatable
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

        var dt = DateTimeOffset.FromUnixTimeMilliseconds((long)selection).UtcDateTime;
        _view.UpdateDate(dt);
    }
}
