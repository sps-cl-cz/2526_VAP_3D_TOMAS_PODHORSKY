string input = Console.ReadLine();
input = input.Replace(" ", "");

double[] numbers = new double[100];
char[] ops = new char[100];
int nIndex = 0;
int oIndex = 0;
string num = "";

for (int i = 0; i < input.Length; i++)
{
    char c = input[i];
    if ((c >= '0' && c <= '9') || c == '.')
    {
        num += c;
    }
    else if (c == '+' || c == '-' || c == '*' || c == '/')
    {
        numbers[nIndex++] = double.Parse(num);
        num = "";
        ops[oIndex++] = c;
    }
}

if (num.Length > 0)
{
    numbers[nIndex++] = double.Parse(num);
}

for (int j = 0; j < oIndex;)
{
    if (ops[j] == '*' || ops[j] == '/')
    {
        double res = (ops[j] == '*') ? numbers[j] * numbers[j + 1] : numbers[j] / numbers[j + 1];
        numbers[j] = res;
        for (int k = j + 1; k < nIndex - 1; k++) numbers[k] = numbers[k + 1];
        for (int k = j; k < oIndex - 1; k++) ops[k] = ops[k + 1];
        nIndex--; oIndex--;
    }
    else j++;
}

while (oIndex > 0)
{
    double res = (ops[0] == '+') ? numbers[0] + numbers[1] : numbers[0] - numbers[1];
    numbers[0] = res;
    for (int k = 1; k < nIndex - 1; k++) numbers[k] = numbers[k + 1];
    for (int k = 0; k < oIndex - 1; k++) ops[k] = ops[k + 1];
    nIndex--; oIndex--;
}

Console.WriteLine(numbers[0]);
