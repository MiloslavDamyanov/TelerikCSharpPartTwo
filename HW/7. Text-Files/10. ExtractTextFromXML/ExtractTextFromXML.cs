using System;
using System.Xml;

// Write a program that extracts from given XML file all the text without the tags. 
class ExtractTextFromXML
{
    static void Main(string[] args)
    {
        XmlTextReader reader = new XmlTextReader("../../file.xml");
        while (reader.Read())
        {
            switch (reader.NodeType)
            {
                case XmlNodeType.Text: // Display the text in each element.
                    Console.WriteLine(reader.Value);
                    break;
            }
        }
    }
}
