var bar = new Factory<Bar>().Create();
Console.WriteLine(bar);

// Invalid, Bar does not define a default/empty constructor
// var foo = new Factory<Foo>().Create();

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