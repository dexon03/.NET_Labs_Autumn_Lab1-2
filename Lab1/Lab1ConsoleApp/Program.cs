using MyLibrary;

var deque = new Deque<int>();

Console.WriteLine("Test PushFront and PushBack");
deque.OnPushFront += (sender, args) => Console.WriteLine("PushFront");

deque.PushFront(1);
deque.PushFront(2);

deque.OnPushBack += (sender, args) => Console.WriteLine("PushBack");

deque.PushBack(3);
deque.PushBack(4);

Console.WriteLine(deque.ToString());

deque.PushFront(0);

Console.WriteLine(deque.ToString());
Console.WriteLine("----------------------------------------------------------");
Console.WriteLine("Test Enumerator");
foreach (var item in deque)
{
    Console.WriteLine(item);
}
Console.WriteLine("----------------------------------------------------------");
Console.WriteLine("Test Reverse");

deque.OnReverse += (sender, args) => Console.WriteLine("Reverse");
deque.Reverse();

Console.WriteLine(deque.ToString());
Console.WriteLine("----------------------------------------------------------");
Console.WriteLine("Test Count");
Console.WriteLine(deque.Count());
Console.WriteLine("----------------------------------------------------------");
Console.WriteLine("Test PopFront and PopBack");

deque.OnPopFront += (sender, args) => Console.WriteLine("PopFront");
deque.OnPopBack += (sender, args) => Console.WriteLine("PopBack");

deque.PopFront();
Console.WriteLine(deque.ToString());
deque.PopBack();
Console.WriteLine(deque.ToString());
Console.WriteLine("----------------------------------------------------------");
Console.WriteLine("Test Peek");
Console.WriteLine("Peek front: " + deque.PeekFront());
Console.WriteLine("Peek back: " + deque.PeekBack());
Console.WriteLine(deque.ToString());
Console.WriteLine("----------------------------------------------------------");
Console.WriteLine("Test Clear");

deque.Clear();

try
{
    deque.PopBack();
}
catch (InvalidOperationException e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine(deque.ToString());
Console.WriteLine("Test is empty: " + deque.IsEmpty());

Console.WriteLine("----------------------------------------------------------");
Console.WriteLine("Test Enumerator on empty created deque");

var deque1 = new Deque<int>();
foreach (var item in deque1)
{
    Console.WriteLine(item);
}
