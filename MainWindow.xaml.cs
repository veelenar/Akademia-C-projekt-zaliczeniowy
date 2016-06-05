using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
