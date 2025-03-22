namespace NativeForms.App;

public sealed partial class MainPage : ContentPage
{
    public DateTimeOffset DateTime
    {
        get;
        set
        {
            if (field == value)
            {
                return;
            }

            OnPropertyChanging();
            field = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(DateTimeString));
        }
    } = DateTimeOffset.Now;

    public string DateTimeString => DateTime.ToString("G");

    public DateOnly Date
    {
        get;
        set
        {
            if (field == value)
            {
                return;
            }

            OnPropertyChanging();
            field = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(DateString));
        }
    } = DateOnly.FromDateTime(DateTimeOffset.Now.DateTime);

    public string DateString => Date.ToString("D");

    public TimeOnly Time
    {
        get;
        set
        {
            if (field == value)
            {
                return;
            }

            OnPropertyChanging();
            field = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(TimeString));
        }
    } = TimeOnly.FromDateTime(DateTimeOffset.Now.DateTime);

    public string TimeString => Time.ToString("T");

    protected override void OnAppearing()
    {
        GC.Collect();
        base.OnAppearing();
    }

    public MainPage()
    {
        var dateTimeLabel = new Label { FontSize = 20, };

        dateTimeLabel.SetBinding(
            Label.TextProperty,
            static (MainPage p) => p.DateTimeString);

        var dateTimePicker = new NativeDateTimePicker
        {
            MinimumDateTime = DateTimeOffset.Now.AddDays(-1),
            MaximumDateTime = DateTimeOffset.Now.AddDays(1),
        };

        dateTimePicker.SetBinding(
            NativeDateTimePicker.DateTimeProperty,
            static (MainPage p) => p.DateTime);

        var dateLabel = new Label { FontSize = 20, };

        dateLabel.SetBinding(
            Label.TextProperty,
            static (MainPage p) => p.DateString);

        var datePicker = new NativeDatePicker { };

        datePicker.SetBinding(
            NativeDatePicker.DateProperty,
            static (MainPage p) => p.Date);

        var timeLabel = new Label { FontSize = 20, };

        timeLabel.SetBinding(
            Label.TextProperty,
            static (MainPage p) => p.TimeString);

        var timePicker = new NativeTimePicker();

        timePicker.SetBinding(
            NativeTimePicker.TimeProperty,
            static (MainPage p) => p.Time);

        Content = new VerticalStackLayout
        {
            Spacing = 16,
            Children =
            {
                dateTimeLabel,
                dateTimePicker,
                dateLabel,
                datePicker,
                timeLabel,
                timePicker,
            }
        };

        BindingContext = this;
    }
}
