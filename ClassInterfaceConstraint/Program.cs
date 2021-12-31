// See https://aka.ms/new-console-template for more information

new NonGeneric().DoSomething(new Type());

// Invalid
// new NonGeneric().DoSomething(new AnotherType());

// Checking equality of generic values
void Foo<TBar>(TBar arg1, TBar arg2)
{
    var comparer = EqualityComparer<TBar>.Default;
    if (comparer.Equals(arg1,arg2))
    {
        
    }
}

// Checking equality of generic values
class NameGetter<T>
{
    public string GetTypeName()
    {
        return typeof(T).Name;
    }
}

interface IType {}
interface IAnotherType {}

// T must be a subtype of IType
interface IGenericType<T>
    where T : IType
{
}

// T must be a subtype of IType
class GenericType<T>
    where T : IType
{
}

class NonGeneric
{
    // T must be a subtype of IType
    public void DoSomething<T>(T arg)
        where T : IType
    {
    }
}

class Type : IType { }
class Sub1 : IGenericType<Type> { }
class Sub2 : GenericType<Type> { }

class AnotherType : IAnotherType { }

// Invalid definitions and expressions:
// class Sub3 : IGenericType<AnotherType> { }
// class Sub4 : GenericType<AnotherType> { }

class GenericType<T, T1>
    where T : IType
    where T1 : Type, new()
{
}

// class A { /* ... */ }
// class B { /* ... */ }
// interface I1 { }
// interface I2 { }
//
// class Generic<T>
//     where T : A, I1, I2
// {
// }

// Compilation error, only one class
// class Generic2<T> where T : A, B 
// {
// }


// Another rule is that the class must be added as the first constraint and then the interfaces:
// class Generic<T>
//     where T : A, I1
// {
// }
//
// class Generic2<T>
//     where T : I1, A //Compilation error
// {
// }