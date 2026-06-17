namespace MojeDatabaze;

public partial class MainPage : ContentPage
{
    private Databaze _databaze;

    public MainPage()
    {
        InitializeComponent();
        _databaze = new Databaze();

        NactiPoznamky();
    }

    private async void NactiPoznamky()
    {
        SeznamPoznamek.ItemsSource = await _databaze.ZiskejPoznamkyAsync();
    }

    private async void Ulozit_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(VstupniText.Text))
        {
            var novaPoznamka = new Poznamka { Text = VstupniText.Text };
            await _databaze.UlozPoznamkuAsync(novaPoznamka);

            VstupniText.Text = string.Empty; 
            NactiPoznamky(); 
        }
    }
}