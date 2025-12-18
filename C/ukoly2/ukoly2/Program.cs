/*
queue<int> vybersuda(queue<int> q)
{
    queue<int> nova = new queue<int>();

    foreach (int x in q)
    {
        if (x % 2 == 0)
            nova.enqueue(x);
    }

    return nova;
}
*/
Queue<string> OdstranDuplicity(Queue<string> q)
{
    Queue<string> nova = new Queue<string>();
    HashSet<string> videne = new HashSet<string>();

    foreach (string x in q)
    {
        if (!videne.Contains(x))
        {
            videne.Add(x);
            nova.Enqueue(x);
        }
    }

    return nova;
}

Stack<int> PrevratZasobnik(Stack<int> original)
{
    Stack<int> obraceny = new Stack<int>();

    while (original.Count > 0)
    {
        int prvek = original.Pop();  
        obraceny.Push(prvek);        
    }

    return obraceny;
}

HashSet<string> PrunikMnozin(HashSet<string> a, HashSet<string> b)
{
    HashSet<string> vysledek = new HashSet<string>();
    /*a.Intersect(b);*/
    foreach (string x in a)
    {
        if (b.Contains(x))
        {
            vysledek.Add(x);
        }
    }

    return vysledek;
}

Dictionary<string, int> SpocitejVyskyt(Stack<string> zasobnik)
{
    Dictionary<string, int> slovnik = new Dictionary<string, int>();

    while (zasobnik.Count > 0)
    {
        string slovo = zasobnik.Pop();

        if (slovnik.ContainsKey(slovo))
        {
            slovnik[slovo]++;
        }
        else
        {
            slovnik[slovo] = 1;
        }
    }

    return slovnik;
}

List<int> cisla = new List<int>()
{
    0, 1, 2, 3, 4, 5, 6
};
List<int>cisla_delitelna_tremi = cisla.Where(x => x % 3 == 0).ToList();
int delitelnePeti = cisla.First(x => x % 5 == 0);

List<int> mocniny = cisla.Select(x => x * x).ToList();
int soucet = cisla.Aggregate((acc, cur) => acc + cur);
int soucet2 = cisla.Sum(x => x);