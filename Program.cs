using System.Xml.Linq;

namespace ConvertJSONtoXML
{
    internal class Program
    {
        public static string json = "{\"VDD\": 44,\"REAL\": 0,\"Perem\": " +
            "1,\"ID\": \"_6QI0HB878014\",\"ND\": \"31426\",\"DD\": " +
            "\"2023-10-16T00:00:00\",\"ORGANIZ\": 1,\"ORG_1C\": \"000002575\",\"CM_1C\": \"00000057345\"}";
        static void Main(string[] args)
        {
            ParseJsonToXml parseJsonToXml = new ParseJsonToXml(json);
            XDocument xDocument = parseJsonToXml.ParseJson();
            Console.WriteLine(xDocument);
        }
    }
}
