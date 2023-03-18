var stack = new Wintellect.PowerCollections.Stack<int>(10);

for (int i = 0; i < stack.Capacity; i++)
{
	stack.Push(i);
}

foreach (int num in stack)
{
	Console.WriteLine(num);
}

Console.ReadLine();