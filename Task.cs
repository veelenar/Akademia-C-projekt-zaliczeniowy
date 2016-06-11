using System;
using System.Windows.Media;
using System.Xml.Serialization;

namespace Task_Manager_CSharp_WPF
{
    [XmlRoot("Task")]
    [XmlInclude(typeof(SimpleTask))]
    [XmlInclude(typeof(ImportantTask))]
    public abstract class Task
    {
        
        public string TaskName { get; set; }
        public string EndingDate { get; set; }
        public DateTime StartDate { get; set; }
        
        public Person ResponsiblePerson { get; set; }
        public abstract Importance Importance { get; }
        public abstract Color Color { get; }
    
    }
}
