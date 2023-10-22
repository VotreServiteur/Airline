using System.Xml;
namespace Airline;

internal class Program
{
    private static XmlDocument xDoc = new XmlDocument();
    public static void Main(string[] args)
    {
           
    }

    public static void ReadXml()
    {
        xDoc.Load("Airline.xml");
    }
}