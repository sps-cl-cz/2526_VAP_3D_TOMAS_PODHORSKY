namespace PrepinacRezimu;

public partial class ThemeSwitcher : ContentView
{
    public ThemeSwitcher()
    {
        InitializeComponent();
    }

    private void ModeSwitch_Toggled(object? sender, ToggledEventArgs e)
    {
        if (Application.Current != null)
        {
            if (e.Value) 
            {
                Application.Current.UserAppTheme = AppTheme.Dark;
            }
            else
            {
                Application.Current.UserAppTheme = AppTheme.Light;
            }
        }
    }
}