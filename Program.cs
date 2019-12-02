using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        var m = typeof(Program).GetMethod(nameof(Foo), BindingFlags.Static | BindingFlags.NonPublic);
        var a = m.GetParameters();
        var s = a.AsSpan(0, 0);
    }

    static void Foo() { }
}
