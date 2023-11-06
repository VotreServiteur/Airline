namespace Airline;
[Serializable]
public class CargoPlane : Plane
{
    protected override void CreateXmlNode()
    {
        throw new NotImplementedException();
    }

    public int LoadPrice { get; set; }

    public CargoPlane(string name, int capacity, int loadCapacity, int crew, int fuelRate, int flightRange, int loadPrice) 
        : base( name, capacity,  loadCapacity, crew, fuelRate, flightRange)
    {
        LoadPrice = loadPrice;
    }

    public CargoPlane()
        : base()
    {
        InputMessage("load price");
        LoadPrice = Convert.ToInt32(Console.ReadLine());

    }

    public override string ToString()
    {
        return base.ToString() + $"Load price: {LoadPrice}\n";
    }
}