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
}
