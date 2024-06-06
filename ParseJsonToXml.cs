using System.Text.Json;
using System.Xml.Linq;

namespace ConvertJSONtoXML
{
    public class ParseJsonToXml(string json)
    {
        public XDocument ParseJson()
        {
            JsonDocument doc = JsonDocument.Parse(json);
            XDocument xDocument = new XDocument();
            JsonElement root = doc.RootElement;
            XElement rootElement = new XElement("root");
            parseElement(root, rootElement);
            xDocument.Add(rootElement);
            return xDocument;
        }

        private void parseElement(JsonElement root, XElement rootElement = null)
        {
            switch (root.ValueKind)
            {
                case JsonValueKind.Undefined:
                    break;
                case JsonValueKind.Object:
                    parseObject(root, rootElement); break;
                case JsonValueKind.String:
                    parseString(root, rootElement); break;
                case JsonValueKind.Number:
                    parseNumber(root, rootElement); break;
                case JsonValueKind.Array:
                    parseArray(root, rootElement); break;
                case JsonValueKind.True:
                case JsonValueKind.False:
                    parseBoolean(root, rootElement); break;
                case JsonValueKind.Null:
                    parseNull(); break;
                default: throw new NotSupportedException($"Неподдерживаемый тип JSON {root.ValueKind}");
            }
        }

        private void parseNull() => Console.WriteLine("Нулевое значение");
        private void parseBoolean(JsonElement root, XElement rootElement) => rootElement.Value = root.GetRawText();
        private void parseNumber(JsonElement root, XElement rootElement) => rootElement.Value = root.GetRawText();
        private void parseString(JsonElement root, XElement rootElement) => rootElement.Value = root.GetString();
        private void parseObject(JsonElement root, XElement rootElement)
        {
            foreach (var element in root.EnumerateObject())
            {
                XElement objectElement = new XElement("text");
                parseElement(element.Value, objectElement);
                rootElement.Add(objectElement);
            }
        }
        private void parseArray(JsonElement root, XElement rootElement)
        {
            foreach (var element in root.EnumerateArray())
            {
                XElement objectElement = new XElement("text");
                parseElement(element, objectElement);
                rootElement.Add(objectElement);
            }
        }
    }
}
