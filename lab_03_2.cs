using System;

class Car
{
    private string name;
    private int engine;
    private double maxSpeed;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Engine
    {
        get { return engine; }
        set { engine = value; }
    }

    public double MaxSpeed
    {
        get { return maxSpeed; }
        set { maxSpeed = value; }
    }

    public Car(string name, int engine, double maxSpeed)
    {
        Name = name;
        Engine = engine;
        MaxSpeed = maxSpeed;
    }

    public override string ToString()
    {
        return Name;
    }
}

class CarComparer : IEquatable<Car>
{
    public bool Equals(Car car1, Car car2)
    {
        if (car1 == null || car2 == null)
            return false;

        return car1.Name == car2.Name && car1.Engine == car2.Engine && car1.MaxSpeed == car2.MaxSpeed;
    }

    public bool Equals(Car? other)
    {
        throw new NotImplementedException();
    }
}

class CarsCatalog
{
    private List<Car> cars;

    public CarsCatalog()
    {
        cars = new List<Car>();
    }

    public void AddCar(Car car)
    {
        cars.Add(car);
    }

    public Car this[int index]
    {
        get
        {
            if (index >= 0 && index < cars.Count)
                return cars[index];
            else
                throw new IndexOutOfRangeException("Индекс находится вне диапазона");
        }
    }
}

class lab_03_2
{
    static void Main()
    {
        Car car1 = new Car("Нормальная машина", 100, 180);
        Car car2 = new Car("Отличная машина", 10000, 10000);

        CarsCatalog catalog = new CarsCatalog();
        catalog.AddCar(car1);
        catalog.AddCar(car2);

        Console.WriteLine("Машина 1: " + catalog[0].Name + " - " + catalog[0].Engine);
        Console.WriteLine("Машина 2: " + catalog[1].Name + " - " + catalog[1].Engine);

        if (Equals(car1, car2))
            Console.WriteLine($"\n{car1} и {car2} идентичны");
        else
            Console.WriteLine($"\n{car1} и {car2} не идентичны");
    }
}