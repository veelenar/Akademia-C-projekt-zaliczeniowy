using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Windows;
using Timer = System.Threading.Timer;

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

        private System.Timers.Timer TimeCounter;
        public IsShown Shown { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            TasksList = new ObservableCollection<Task>();

            TasksList.Add(new SimpleTask()
            {
                ResponsiblePerson = new Person() { Name = "Kacper" },
                EndingDate = DateTime.Now.AddHours(1).AddMinutes(1).ToString("dd-MM-yyyy HH:mm"),
                TaskName = "Leniuchowanie"
            });

            TasksList.Add(new ImportantTask()
            {
                ResponsiblePerson = new Person() { Name = "Piotr" },
                EndingDate = DateTime.Now.AddDays(1).AddMinutes(2).ToString("dd-MM-yyyy HH:mm"),
                TaskName = "Leniuchowanie bardziej"
            });

            TasksList.Add(new ImportantTask()
            {
                ResponsiblePerson = new Person() { Name = "Kasia" },
                EndingDate = DateTime.Now.AddDays(1).ToString("dd-MM-yyyy HH:mm"),
                TaskName = "Leniuchowanie jeszcze bardziej"
            });

            Shown = IsShown.no;
            foreach (var task in TasksList)
            {
                if (task.EndingDate == DateTime.Now.AddDays(1).ToString("dd-MM-yyyy HH:mm"))
                {
                    if (Shown == IsShown.no)
                    {
                        MessageBox.Show("One of your tasks is going to meet deadline tomorrow!\nCheck tasklist for further information.",
                            "Announcement - deadline tomorrow", MessageBoxButton.OK, MessageBoxImage.Information);
                        Shown = IsShown.yes;
                        
                    }
                }
                else if (task.EndingDate == DateTime.Now.AddHours(1).ToString("dd-MM-yyyy HH:mm"))
                {
                    if (Shown == IsShown.no)
                    {
                        MessageBox.Show("One of your tasks is going to meet deadline in one hour!\nCheck tasklist for further information.",
                            "Announcement - deadline in one hour", MessageBoxButton.OK, MessageBoxImage.Information);
                        Shown = IsShown.yes;
                        
                    }
                }
                else if (task.EndingDate == DateTime.Now.AddHours(12).ToString("dd-MM-yyyy HH:mm"))
                {
                    if (Shown == IsShown.no)
                    {
                        MessageBox.Show("One of your tasks is going to meet deadline in 12 hours!\nCheck tasklist for further information.",
                            "Announcement - deadline in one hour", MessageBoxButton.OK, MessageBoxImage.Information);
                        Shown = IsShown.yes;
                    }
                }
                else if (task.EndingDate == DateTime.Now.AddHours(6).ToString("dd-MM-yyyy HH:mm"))
                {
                    if (Shown == IsShown.no)
                    {
                        MessageBox.Show("One of your tasks is going to meet deadline in 6 hours!\nCheck tasklist for further information.",
                            "Announcement - deadline in one hour", MessageBoxButton.OK, MessageBoxImage.Information);
                        Shown = IsShown.yes;
                    }
                }
            }
            Shown = IsShown.no;

            TimeCounter = new System.Timers.Timer(60000);
            TimeCounter.Elapsed += TimeCounter_Elapsed;
            TimeCounter.Start();

            OnPropertyChanged(nameof(TasksList));
        }

        private void TimeCounter_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            foreach (var task in TasksList)
            {
                if (task.EndingDate == DateTime.Now.AddDays(1).ToString("dd-MM-yyyy HH:mm"))
                {
                    if (Shown == IsShown.no)
                    {
                        MessageBox.Show("One of your tasks is going to meet deadline tomorrow!\nCheck tasklist for further information.",
                            "Announcement - deadline tomorrow", MessageBoxButton.OK, MessageBoxImage.Information);
                        Shown = IsShown.yes;
                    }
                }
                else if (task.EndingDate == DateTime.Now.AddHours(1).ToString("dd-MM-yyyy HH:mm"))
                {
                    if (Shown == IsShown.no)
                    {
                        MessageBox.Show("One of your tasks is going to meet deadline in 1 hour!\nCheck tasklist for further information.",
                            "Announcement - deadline in one hour", MessageBoxButton.OK, MessageBoxImage.Information);
                        Shown = IsShown.yes;
                    }
                }
                else if (task.EndingDate == DateTime.Now.AddHours(12).ToString("dd-MM-yyyy HH:mm"))
                {
                    if (Shown == IsShown.no)
                    {
                        MessageBox.Show("One of your tasks is going to meet deadline in 12 hours!\nCheck tasklist for further information.",
                            "Announcement - deadline in one hour", MessageBoxButton.OK, MessageBoxImage.Information);
                        Shown = IsShown.yes;
                    }
                }
                else if (task.EndingDate == DateTime.Now.AddHours(6).ToString("dd-MM-yyyy HH:mm"))
                {
                    if (Shown == IsShown.no)
                    {
                        MessageBox.Show("One of your tasks is going to meet deadline in 16 hours!\nCheck tasklist for further information.",
                            "Announcement - deadline in one hour", MessageBoxButton.OK, MessageBoxImage.Information);
                        Shown = IsShown.yes;
                    }
                }
            }
            Shown = IsShown.no;
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
