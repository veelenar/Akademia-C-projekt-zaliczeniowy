using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows;

namespace Task_Manager_CSharp_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Task> TasksList { get; set; }

        public Task SelectedTask { get; set; }

        public enum IsShown
        {
            no,
            yes
        };

        public IsShown Shown { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            TasksList = new ObservableCollection<Task>();

            TasksList.Add(new SimpleTask()
            {
                ResponsiblePerson = new Person() { Name = "Kacper" },
                EndingDate = DateTime.Now.AddDays(1),
                TaskName = "Leniuchowanie"
            });

            TasksList.Add(new ImportantTask()
            {
                ResponsiblePerson = new Person() { Name = "Piotr" },
                EndingDate = DateTime.Now.AddDays(1),
                TaskName = "Leniuchowanie bardziej"
            });
            Shown = IsShown.no;
            foreach (var task in TasksList)
            {
                if (task.EndingDate == DateTime.Now.AddDays(1))
                {
                    if (Shown == IsShown.no)
                    {
                        AnnouncementWindow openAnnouncementWindow = new AnnouncementWindow();
                        openAnnouncementWindow.ShowDialog();
                        Shown = IsShown.yes;
                    }
                }
            }



            OnPropertyChanged(nameof(TasksList));
        }




        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            NewTaskWindow taskWindow = new NewTaskWindow();

            taskWindow.ShowDialog();

            if (taskWindow.DialogResult.HasValue && taskWindow.DialogResult.Value)
            {
                TasksList.Add(taskWindow.NewTask);
            }
           
        }

        private void DeteleTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTask != null)
            {
                if (MessageBox.Show("Are you sure you want to delete this task?", "Delete task", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    TasksList.Remove(SelectedTask);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
