namespace Airline;

public abstract class Plane
{
    public string Name { get; set; }
    
    public int Capacity { get; set; }
    public int LoadCapacity { get; set; }
    public int Crew { get; set; }
    
    public int FuelRate { get; set; }
    public int FlightRange { get; set; }

    protected Plane(string name, int capacity, int loadCapacity, int crew, int fuelRate, int flightRange)
    {
        Name = name;
        Capacity = capacity;
        LoadCapacity = loadCapacity;
        Crew = crew;
        FuelRate = fuelRate;
        FlightRange = flightRange;
    }

    protected Plane()
    {
        var readInt = Convert.ToInt32(Console.ReadLine());
        InputMessage("plane name");
        Name = Console.ReadLine() ?? "Plane";
        InputMessage("capacity");
        Capacity = readInt;
        InputMessage("load capacity");
        LoadCapacity = readInt;
        InputMessage("number of crew");
        Crew = readInt;
        InputMessage("fuel rate");
        FuelRate = readInt;
        InputMessage("flight range");
        FlightRange = readInt;

    }

    public void InputMessage(string msg) =>
        Console.WriteLine($"Input {msg}\n\t: ");    
    }