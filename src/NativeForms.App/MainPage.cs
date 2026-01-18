namespace NativeForms.App;

public sealed partial class MainPage : ContentPage
{
    public DateTime DateTime
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
    } = DateTime.Now;

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

    public DateOnly MauiDate
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
            OnPropertyChanged(nameof(MauiDateString));
        }
    } = DateOnly.FromDateTime(DateTimeOffset.Now.DateTime);

    public string MauiDateString => MauiDate.ToString();

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
            MinimumDateTime = DateTime.Now.AddDays(-1),
            MaximumDateTime = DateTime.Now.AddDays(1),
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

        var mauiLabel = new Label { FontSize = 20 };

        mauiLabel.SetBinding(
            Label.TextProperty,
            static (MainPage p) => p.MauiDateString);

        var mauiPicker = new DatePicker();

        mauiPicker.SetBinding(
            DatePicker.DateProperty,
            static (MainPage p) => p.MauiDate);

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
