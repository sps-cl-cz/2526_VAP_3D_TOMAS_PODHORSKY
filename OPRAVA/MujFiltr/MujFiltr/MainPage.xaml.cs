using System.Collections.ObjectModel;

namespace MujFiltr;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        var vsechnaData = new ObservableCollection<Produkt>
        {
            new Produkt { Nazev = "Jablko", Kategorie = "Ovoce" },
            new Produkt { Nazev = "Banán", Kategorie = "Ovoce" },
            new Produkt { Nazev = "Mrkev", Kategorie = "Zelenina" },
            new Produkt { Nazev = "Brambora", Kategorie = "Zelenina" },
            new Produkt { Nazev = "Chléb", Kategorie = "Pečivo" }
        };

        MujHledac.ItemsSource = vsechnaData;
    }
}