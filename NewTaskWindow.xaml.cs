using System.Collections.ObjectModel;
using System.Windows;

namespace Task_Manager_CSharp_WPF
{

    /// <summary>
    /// Interaction logic for NewTaskWindow.xaml
    /// </summary>
    public partial class NewTaskWindow : Window
    {
        public ObservableCollection<CreateTask> Tasks { get; set; }
        public NewTaskWindow()
        {
            InitializeComponent();
            
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonAddTask_Click(object sender, RoutedEventArgs e)
        {
            Tasks = new ObservableCollection<CreateTask>();

        }
    }
}
