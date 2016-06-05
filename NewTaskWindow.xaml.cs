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
using System.Windows.Shapes;

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
