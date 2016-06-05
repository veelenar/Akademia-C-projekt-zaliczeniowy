using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager_CSharp_WPF
{
    public class Task
    {
        public string TaskName { get; set; }
        public Date EndingDate { get; set; }
        public Person ResponsiblePerson { get; set; }
        
        public virtual string GetEndingDate()
        {
            return "data";
        }
    }

    public class CreateTask : Task
    {
        public CreateTask() { }

        public CreateTask(string taskname, string surname, string name, int day, int month, int year)
        {
            this.TaskName = taskname;
            this.EndingDate.Day = day.ToString();
            this.EndingDate.Month = month.ToString();
            this.EndingDate.Year = year.ToString();
            this.ResponsiblePerson.Name = name;
            this.ResponsiblePerson.Surname = surname;
        }

        public override string GetEndingDate()
        {
            return this.EndingDate.Day + "." + this.EndingDate.Month + "." + this.EndingDate.Year;
        }
    }
}
