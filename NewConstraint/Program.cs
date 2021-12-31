﻿var type = new Factory<Bar>().Create();
Console.WriteLine(type);

public class Foo
{
    public Foo(int a)
    {

    }
}

public class Bar
{

}

class Factory<T> where T : new()
{
    public T Create()
    {
        return new T();
    }
}