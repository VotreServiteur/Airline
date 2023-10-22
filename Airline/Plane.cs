namespace Airline;

public abstract class Plane
{
    public string Name { get; set; } = "Undefined";
    
    public int Capacity { get; set; } = 0;
    public int LoadCapacity { get; set; } = 0;
    public int Crew { get; set; } = 0;
    
    public int FuelRate { get; set; } = 0;
    public int FlightRange { get; set; } = 0;

    
}