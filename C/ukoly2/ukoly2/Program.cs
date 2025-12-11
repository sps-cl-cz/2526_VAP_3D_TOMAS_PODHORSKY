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

