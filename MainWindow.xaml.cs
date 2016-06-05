using System.Collections.ObjectModel;
using System.Windows;

namespace Task_Manager_CSharp_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<CreateTask> TasksList { get; set; }
        enum IsShown
        {
            no,
            yes
        };

        public MainWindow()
        {
            InitializeComponent();

        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
           NewTaskWindow OpenNewTaskWindow = new NewTaskWindow();
            OpenNewTaskWindow.ShowDialog();
        }

        private void DeteleTaskButton_Click(object sender, RoutedEventArgs e)
        {
            AnnouncementWindow OpenAnnouncementWindow = new AnnouncementWindow();
            OpenAnnouncementWindow.ShowDialog();
        }
    }
}
