namespace MujFiltr;

public partial class FiltrKontrolka : ContentView
{
    public event EventHandler<string> FiltrZmenen;

    public FiltrKontrolka()
    {
        InitializeComponent();
    }

    private void HledaciPole_TextChanged(object sender, TextChangedEventArgs e)
    {
        FiltrZmenen?.Invoke(this, e.NewTextValue);
    }
}