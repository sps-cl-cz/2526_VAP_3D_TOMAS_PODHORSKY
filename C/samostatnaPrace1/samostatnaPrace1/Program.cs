static string VypocetPrumerneRychlosti(double vzdalenostKm, double casMin)
{
    if (vzdalenostKm < 0 || casMin < 0)
        return "Neplatné hodnoty";

    if (casMin == 0 && vzdalenostKm > 0)
        return "Nelze vypočítat (dělení nulou)";

    double rychlost = vzdalenostKm / (casMin / 60.0);
    return $"Průměrná rychlost: {rychlost:F2} km/h";
}
Console.WriteLine(VypocetPrumerneRychlosti(10, 30));

static int PocetSamohlasek(string text)
{
    if (string.IsNullOrEmpty(text))
        return 0;

    string samohlasky = "aeiouyáéěíóúůý";
    text = text.ToLower();

    int pocet = 0;

    foreach (char c in text)
    {
        if (samohlasky.Contains(c))
            pocet++;
    }

    return pocet;
}
Console.WriteLine(PocetSamohlasek("Ahoj světe"));

static List<int> ZpracujPole(int[] pole)
{
    if (pole == null)
        return new List<int>();

    HashSet<int> set = new HashSet<int>();

    foreach (int x in pole)
        if (x >= 0)
            set.Add(x);

    List<int> vysledek = set.ToList();
    vysledek.Sort();

    return vysledek;
}

Console.WriteLine(string.Join(", ", ZpracujPole(new int[] { 3, 1, -2, 3, 0, 1, 5, 10 })));
