using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hilos
{
    public class MyClass
    {
        int _seconds;
        public delegate void Seconds(int n);
        public event Seconds? SecondsChanged;

        public MyClass()
        {
            Console.WriteLine($"Child Thread: {Environment.CurrentManagedThreadId}");
            _seconds = 0;
        }

        public async Task DoSomething() 
        { 
            do
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                _seconds++;
                OnSecondsChanged();

            } while (true);
        }

        protected virtual void OnSecondsChanged()
        {
            SecondsChanged?.Invoke(_seconds);
        }

    }
}
