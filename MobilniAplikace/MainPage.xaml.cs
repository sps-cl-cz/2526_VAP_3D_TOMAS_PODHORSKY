public partial class MainPage : ContentPage
{
    private readonly HttpClient _httpClient = new();

    public MainPage()
    {
        InitializeComponent();
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/148.0.0.0 Safari/537.36");
    }

    private async void OnLoadWeatherClicked(object sender, EventArgs e)
    {
        try
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

            var location = await Geolocation.GetLocationAsync(request);

            if (location is null)
            {
                await DisplayAlert("Chyba", "Nelze získat polohu", "OK");
                return;
            }

            string lat = location.Latitude.ToString().Replace(",", ".");
            string lon = location.Longitude.ToString().Replace(",", ".");

            var url = $"https://nominatim.openstreetmap.org/reverse?lat={lat}&lon={lon}&format=jsonv2&accept-language=cs";

            var json = await _httpClient.GetStringAsync(url);
            Place? place = JsonSerializer.Deserialize<Place>(json);
            LocationLabel.Text = $"Poloha: {place?.DisplayName}";

            var weatherUrl = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&current=temperature_2m,weather_code&hourly=temperature_2m,weather_code&timezone=auto";
            var weatherJson = await _httpClient.GetStringAsync(weatherUrl);
            Weather? weather = JsonSerializer.Deserialize<Weather>(weatherJson);
            WeatherLabel.Text = $"Teplota: {weather?.CurrentWeather.Temperature}°C";

            WeatherIcon.Source = ImageSource.FromFile("clear.png");
        
        }
        catch (Exception ex)
        {
            await DisplayAlert("Chyba", ex.Message, "OK");
        }
    }
}