//----------------------------------------------------------------------------
using Hilos;

Console.WriteLine($"Main Thread: {Environment.CurrentManagedThreadId}");

//Creo una nueva tarea que va a ejecutar la función asincrónica DoSomething
var t = Task.Factory.StartNew(() => { _ = DoSomething(); });
var rnd = new Random();

while (true)
{
    Console.Write(".");
    Thread.Sleep(200);
}

//----------------------------------------------------------------------------

//Evento
static void EventSeconds(int n)
{
    Console.WriteLine($"{n} segundos");
}

//Función asincrónica
static async Task<MyClass>DoSomething()
{
    var c = new MyClass();
    //Registro el eveno
    c.SecondsChanged += EventSeconds;
    await c.DoSomething();
    return c;
}

