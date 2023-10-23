namespace Airline;

public class PassengerPlane:Plane
{
    public int AmountOfPassengers { get; set; } = 0;

    public PassengerPlane(string name, int capacity, int loadCapacity, int crew, int fuelRate, int flightRange, int amountOfPassengers) 
        : base( name, capacity,  loadCapacity, crew, fuelRate, flightRange)
    {
        AmountOfPassengers = amountOfPassengers;
    }

    protected PassengerPlane()
        : base()
    {
        InputMessage("amount of passengers");
        AmountOfPassengers = Convert.ToInt32(Console.ReadLine());
    }
}