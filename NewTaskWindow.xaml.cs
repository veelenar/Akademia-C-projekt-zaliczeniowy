using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;

namespace Task_Manager_CSharp_WPF
{

    /// <summary> Interaction logic for NewTaskWindow.xaml
    /// </summary>
    public partial class NewTaskWindow : Window
    {
        private Task newTask;
        
        public NewTaskWindow()
        {
            InitializeComponent();
        }

        public Task NewTask
        {
            get { return newTask; }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void ButtonAddTask_Click(object sender, RoutedEventArgs e)
        {

            if (SimpleRadio.IsChecked.HasValue && SimpleRadio.IsChecked.Value)
            {
                newTask = new SimpleTask();
            }
            else if (ImportantRadio.IsChecked.HasValue && ImportantRadio.IsChecked.Value)
            {
                newTask = new ImportantTask();
            }
            else
            {
                MessageBox.Show("Importance is not selected!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (EndingDatePicker.SelectedDate != null)
                newTask.EndingDate = EndingDatePicker.SelectedDate.Value;
            else
            {
                MessageBox.Show("Date is not selected!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            newTask.ResponsiblePerson = new Person()
            {
                Name = TextBoxResponsiblePerson.Text
            };

            newTask.StartDate = DateTime.Now;

            newTask.TaskName = TextBoxTaskName.Text;
            
            this.DialogResult = true;
            this.Close();
        }        
    }

}
