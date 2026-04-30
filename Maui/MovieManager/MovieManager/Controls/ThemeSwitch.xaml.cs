namespace ProjectManager.Controls;

public partial class ThemeSwitch : ContentView
{
    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(ThemeSwitch), string.Empty);

    public static readonly BindableProperty OrientationProperty =
        BindableProperty.Create(nameof(Orientation), typeof(StackOrientation), typeof(ThemeSwitch), StackOrientation.Horizontal);

    public static readonly BindableProperty IsDarkModeProperty =
        BindableProperty.Create(nameof(IsDarkMode), typeof(bool), typeof(ThemeSwitch), false);

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public StackOrientation Orientation
    {
        get => (StackOrientation)GetValue(OrientationProperty);
        set => SetValue(OrientationProperty, value);
    }

    public bool IsDarkMode
    {
        get => (bool)GetValue(IsDarkModeProperty);
        set => SetValue(IsDarkModeProperty, value);
    }

    public ThemeSwitch()
    {
        InitializeComponent();

        if (Application.Current != null)
        {
            IsDarkMode = Application.Current.RequestedTheme == AppTheme.Dark;
        }
    }

    private void OnThemeToggled(object sender, ToggledEventArgs e)
    {
        if (Application.Current != null)
        {
            Application.Current.UserAppTheme = e.Value ? AppTheme.Dark : AppTheme.Light;
        }
    }
}