using System.Xml;
using System.Xml.Linq;
using static System.Console;
using static System.Convert;

namespace Airline;

/*
 Авиакомпания. Определить иерархию самолетов. Создать авиакомпанию. Посчитать общую
вместимость и грузоподъемность. Провести сортировку самолетов компании по дальности
полета. Найти самолет в компании, соответствующий заданному диапазону параметров
потребления горючего.
*/
internal class Program
{
    private static XmlDocument xDoc = new XmlDocument();

    private static List<Plane> airline = new();


    public static void Main(string[] args)
    {
        xDoc.Load(@"airline.xml");
        
        XmlElement? xRoot = xDoc.DocumentElement;
        if (xRoot != null)
        {
            foreach (XmlElement xNode in xRoot)
            {
                if (xNode.Attributes.GetNamedItem("type")!.Value!.Equals("P"))
                    airline.Add(new PassengerPlane(xNode));
                else
                    airline.Add(new CargoPlane(xNode));
            }
        }

/*
        Write("Count of planes: ");
        int count = ToInt32(ReadLine());
        for (int i = 0; i < count; i++)
        {
            airline.Add(CreatePlane());
        }
*/
        bool cycle = true;
        while (cycle)
        {
            Write("""
                  1. Show planes
                  2. Add plane
                  3. Delete plane
                  4. Sort airline
                  5. Find a plane

                  0. Exit
                      >
                  """ + " ");
            switch (ToInt32(ReadLine()))
            {
                case 1:
                    ShowPlanes();
                    Write($"Total capacity - {Plane.TotalCapacity}\nTotal load capacity - {Plane.TotalLoadCapacity}\n\n");
                    break;
                case 2:
                    airline.Add(CreatePlane());
                    break;
                case 3:
                    DeletePlane();
                    break;
                case 4:
                    airline.Sort((Plane x, Plane y) => x.FlightRange.CompareTo(y.FlightRange));
                    break;
                case 5:
                    FindPlane();
                    break;
                case 0:
                    WriteLine("Saving data");
                    xDoc.Save("airlinetemp.txt");
                    var doc = new XDocument();
                    XElement planes = new XElement("planes");

                    foreach (var plane in airline)
                    {
                        planes.Add(plane.CreateXmlNode());
                    }

                    doc.Add(planes);
                    doc.Save("airline.xml");
                    cycle = false;
                    break;
            }
        }
    }

    private static void FindPlane()
    {
        int minRate, maxRate;
        Write($"Input minimal rate: {minRate = ToInt32(ReadLine())}" +
              $"Input maximal rate: {maxRate = ToInt32(ReadLine())}");


        foreach (var plane in airline)
        {
            if (plane.FuelRate >= minRate && plane.FuelRate <= maxRate) Write(plane.ToString());
        }
    }

    private static void DeletePlane()
    {
        ShowPlanes();
        Write("Choose plane to delete:\n    >");
        airline.RemoveAt(ToInt32(ReadLine()) - 1);
    }

    private static void ShowPlanes()
    {
        WriteLine();
        int num = 1;
        foreach (var plane in airline)
        {
            Write(num++ + plane.ToString());
        }
        WriteLine();
    }

    public static Plane CreatePlane()
    {
        Write("""
                1. Passenger plane
                2. Cargo plane
                    >
              """);
        Write(" ");
        return ToInt32(ReadLine()) == 1 ? new PassengerPlane() : new CargoPlane();
    }

    public static void ReadXml()
    {
        xDoc.Load("Airline.xml");
    }
}