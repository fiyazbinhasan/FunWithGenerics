// See https://aka.ms/new-console-template for more information

var grass = new Grass(); 
var sheep = new Herbivore();
var lion = new Carnivore();
 
sheep.Eat(grass);
lion.Eat(sheep);

// It won't be possible because the object lion does not implement the interface IFood
// sheep.Eat(lion);

public interface IFood
{
    void EatenBy(Animal animal);
}

public class Grass: IFood
{
    public void EatenBy(Animal animal)
    {
        Console.WriteLine("Grass was eaten by: {0}", animal.Name);
    }
}

public class Animal
{
    public string? Name { get; protected init; }
    public void Eat<TFood>(TFood food)
        where TFood : IFood
    {
        food.EatenBy(this);
    }
}

public class Carnivore : Animal
{
    public Carnivore()
    {
        Name = "Carnivore";
    }
}

public class Herbivore : Animal, IFood
{
    public Herbivore()
    {
        Name = "Herbivore";
    }
 
    public void EatenBy(Animal animal)
    {
        Console.WriteLine("Herbivore was eaten by: {0}", animal.Name);
    }
}