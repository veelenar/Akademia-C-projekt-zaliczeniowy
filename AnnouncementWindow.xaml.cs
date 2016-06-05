using System.Windows;

namespace Task_Manager_CSharp_WPF
{
    /// <summary>
    /// Interaction logic for AnnouncementWindow.xaml
    /// </summary>
    public partial class AnnouncementWindow : Window
    {
        public AnnouncementWindow()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
