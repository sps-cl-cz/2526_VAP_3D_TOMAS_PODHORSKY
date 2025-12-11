Queue<int> ints = new Queue<int>();
ints.Enqueue(1);
int a = ints.Dequeue();

Stack<int> ints2 = new Stack<int>();
ints2.Push(1);
a = ints2.Pop();
ints2.Peek();
int pocet = ints2.Count;

HashSet<int> ints3 = new HashSet<int> { 1 };
ints3.Contains(1);

Dictionary<int, int> ints4 = new()
{
    [2] = 123,
};

ints4.TryGetValue(2, out int hodnota);
hodnota = ints4[2];
ints4[2] = hodnota;


