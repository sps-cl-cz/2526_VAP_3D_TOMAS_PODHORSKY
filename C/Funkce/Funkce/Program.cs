double ObsahTrojuhelniku(double zakladna, double vyska)
{
    return 0.5 * zakladna * vyska;
}

string FormatujCislo(double cislo)
{
    string output = "";
    string cisloString = cislo.ToString();
    for (int i = cisloString.Length-1; i >= 0; i--)
    {
        if (i % 3 == 0) output = " " + output;
        output = cisloString[i] + output;
    }
    return output;
}

int PocetRozdilnychZnaku(string a, string b)
{
    int delsi = Math.Max(a.Length, b.Length);
    int rozdily = 0;

    for (int i = 0; i < delsi; i++)
    {
        char ca = i < a.Length ? a[i] : '\0';
        char cb = i < b.Length ? b[i] : '\0';

        if (ca != cb) rozdily++;
    }

    return rozdily;
}

string ProhodSlova(string text)
{
    string[] casti = text.Split(' ');
    if (casti.Length < 2) return text;
    return casti[1] + " " + casti[0];
}

int CifernySoučet(int cislo)
{
    cislo = Math.Abs(cislo);

    int soucet = 0;

    while (cislo > 0)
    {
        int cifra = cislo % 10;
        soucet += cifra;
        cislo /= 10;
    }

    return soucet;
}

bool JePalindrom(string slovo)
{
    slovo = slovo.ToLower();

    string obracene = new string(slovo.Reverse().ToArray());
    return slovo == obracene;
}

List<double> VratKladnaCisla(double[] cisla)
{
    List<double> vysledek = new List<double>();
    foreach (double c in cisla)
    {
        if (c > 0) vysledek.Add(c);
    }
    return vysledek;
}

T Vetsi<T>(T jedna, T dva) where T : IComparable
{
    if (jedna.CompareTo(dva) > 0)
        return dva;
    return jedna;
}

string vetsiText = Vetsi("123", "456");
int vetsicislo = Vetsi(123, 456);

Action<string> a = (text) =>
{
    Console.WriteLine("Ahoj");
};

a("ahoj");
a?.Invoke("ahoj");

Func<string, int> f = (text) =>
{
    return text.Length;
};