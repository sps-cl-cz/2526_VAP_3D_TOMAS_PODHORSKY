// Hodnotové datové typy
using System.Data;

int cislo1 = 0;
int cislo2 = cislo1;
cislo1 = 2;

// Čiselné datové typy
byte    b  = 0;     // 8-bit unsigned integer  (0, 255)
short   s  = 0;     // 16-bit signed integer   (-32 768, 32 767)
ushort  us = 0;     // 16-bit unsigned integer (0, 65 535)
int     i  = 0;     // 32-bit signed integer   (-2 147 483 648, 2 147 483 647)
uint    ui = 0;     // 32-bit unsigned integer (0, 4 294 967 295)
long    l  = 0;     // 64-bit signed integer   (-9 223 372 036 854 775 808, 9 223 372 036 854 775 807)
ulong   ul = 0;     // 64-bit unsigned integer (0, 18 446 744 073 709 551 615)

// Desetinné datové typy
float   f  = 0.1f;  // 32-bit signed float (-3,4028235E+38, 3,4028235E+38)
double  d  = 0.1;   // 64-bit signed float (-1,7976931348623157E+308, 1,7976931348623157E+308)
decimal dc = 0.1m;  // 128-bit signed float (-79 228 162 514 264 337 593 543 950 335, 79 228 162 514 264 337 593 543 950 335)

// 
bool    bl = false; // 1-bit boolean (true, false)  NEUMÍ PŘEVOD 1, 0
char    ch = 'a';   // 16-bit character             MUSÍ MÍT JEDNODUCHÉ UVOZOVKY
//referencni datovy typ
string  st = "b";   // vícero char za sebou

int[] ints = new int[20];

int[][] matrix = new int[20][];
for (int j = 0; j < matrix.Length; j++)
{
    matrix[j] = new int[20];
    for (int k = 0; k < matrix.Length; k++)
    {
        matrix[j][k] = k + 1 + j * 20;
    }
}

int[,] matrix2 = new int[20, 20];
for (int j = 0; j < matrix2.GetLength(0); j++)
{
    for (int k = 0; k < matrix2.GetLength(1); k++)
    {
        matrix2[j, k] = k + 1 + j * 20;
    }
}

List<int> list = new List<int>();
for (int j = 0; j < 20; j++)
{
    list.Add(j + 1);
}
list.RemoveAt(19);
int count = list.Count;

string input = Console.ReadLine();
string[] parts = input.Split(';');
for (int j = 0; j < parts.Length; j++)
{
    Console.WriteLine(parts[j]);
}