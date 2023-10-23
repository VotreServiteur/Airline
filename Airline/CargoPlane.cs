namespace Airline;

public class CargoPlane:Plane
{
    public CargoPlane(string name, int capacity, int loadCapacity, int crew, int fuelRate, int flightRange, int amountOfPassengers) 
        : base( name, capacity,  loadCapacity, crew, fuelRate, flightRange)
    {
        
    }

    public CargoPlane()
        : base()
    {

    }
}