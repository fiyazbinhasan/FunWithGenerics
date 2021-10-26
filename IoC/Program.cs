using System;
using System.Collections.Generic;

namespace IoC
{
    class Employee
    {
        public string Name { get; set; }

        public void Speak<T>()
        {
            Console.WriteLine(typeof(T).Name);
        }
    }

    class Tuple<T, U>
    {
        private readonly T value1;
        private readonly U value2;

        public Tuple(T value1, U value2)
        {
            this.value1 = value1;
            this.value2 = value2;
        }
    }

    static class Tuple
    {
        public static Tuple<T1, T2> Create<T1, T2>(T1 value1, T2 value2)
        {
            return new Tuple<T1, T2>(value1, value2);
        }
    }

    public interface IFood
    {
        void EatenBy(Animal animal);
    }
    public class Grass : IFood
    {
        public void EatenBy(Animal animal)
        {
            Console.WriteLine("Grass was eaten by: {0}", animal.Name);
        }
    }

    public class Animal
    {
        public string Name { get; set; }
        public void Eat<TFood>(TFood food) where TFood : IFood
        {
            food.EatenBy(this);
        }
    }

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

    class Program
    {
        static void Main(string[] args)
        {
            var tuple = Tuple.Create("Hello", "World");

            var goat = new Animal { Name = "Goat" };
            goat.Eat(new Grass());

            var factory = new Factory<Bar>();

            //var employeeList = CreateInstance(typeof(List<>), typeof(Employee));
            //Console.WriteLine(employeeList.GetType().Name);
            //var genericParameters = employeeList.GetType().GetGenericArguments();

            //foreach (var item in genericParameters)
            //{
            //    Console.WriteLine(item);
            //}

            //var employee = new Employee();
            //var speak = typeof(Employee).GetMethod("Speak");
            //speak = speak.MakeGenericMethod(typeof(DateTime));
            //speak.Invoke(employee, null);
        }

        private static object CreateInstance(Type collectionType, Type itemType)
        {
            var type = collectionType.MakeGenericType(itemType);
            return Activator.CreateInstance(type);
        }
    }
}
