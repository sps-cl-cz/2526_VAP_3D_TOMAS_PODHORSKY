using System.Collections.Generic;

Console.WriteLine("Queue, fronta");
Queue<string> queue = new Queue<string>();

queue.Enqueue("Jedna");
queue.Enqueue("Dva");

Console.WriteLine(queue.Peek());    // Vypíše Jedna
Console.WriteLine(queue.Dequeue()); // Vypíše Jedna a smaže z queue
Console.WriteLine(queue.Dequeue()); // Vypíše Dva a smaže z queue
//Console.WriteLine(queue.Dequeue()); // Vypíše chybu

Console.WriteLine("List, seznam");
List<string> list = new List<string>();
list.Add("Jedna");
list.Add("Dva");

list.RemoveAt(0); // Smaže Jedna
list.RemoveAt(0); // Smaže Dva


Console.WriteLine("Stack, zásobník");
Stack<string> stack = new Stack<string>();
stack.Push("Jedna");
stack.Push("Dva");

Console.WriteLine(stack.Peek());    // Vypíše Dva
Console.WriteLine(stack.Pop());     // Vypíše Dva a smaže
Console.WriteLine(stack.Pop());     // Vypíše Jedna a smaže


Console.WriteLine("HashSet, ");
HashSet<string> hashSet = new HashSet<string>();

hashSet.Add("Jedna");   // Přídá
hashSet.Add("Dva");     // Přídá
hashSet.Add("Dva");     // Nepřidá, bez chyby


Dictionary<string, int> dictionary = new Dictionary<string, int>();
dictionary.Add("Jedna", 1);
dictionary.Add("Dva", 2);


