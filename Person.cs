using System.Xml.Serialization;

namespace Task_Manager_CSharp_WPF
{
    [XmlRoot("Person")]
    public class Person
    {
        public string Name { get; set; }
    }
}
