using System.Xml;

namespace Airline;
[Serializable]
public class PassengerPlane:Plane
{
    public int AmountOfPassengers { get; set; } = 0;

    public PassengerPlane(XmlElement xNode) : base(xNode)
    {
        AmountOfPassengers = Convert.ToInt32(xNode.LastChild?.InnerText);
    }
        
    public PassengerPlane(string name, int capacity, int loadCapacity, int crew, int fuelRate, int flightRange, int amountOfPassengers) 
        : base( name, capacity,  loadCapacity, crew, fuelRate, flightRange)
    {
        AmountOfPassengers = amountOfPassengers;
    }

    public PassengerPlane()
        : base()
    {
        InputMessage("amount of passengers");
        AmountOfPassengers = Convert.ToInt32(Console.ReadLine());
        
    }

    protected override void CreateXmlNode()
    {
        
    }

    public override string ToString()
    {
        return base.ToString() + $"Amount if passengers: {AmountOfPassengers}\n";
    }
}