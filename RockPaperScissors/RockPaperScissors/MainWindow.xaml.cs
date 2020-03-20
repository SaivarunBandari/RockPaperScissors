using System.Windows;

namespace RockPaperScissors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VM obj;
        public MainWindow()
        {
            InitializeComponent();
            obj = new VM();
            DataContext = obj;
            obj.ResetData();
        }

        private void BtnRock_Click(object sender, RoutedEventArgs e)
        {
            obj.ComputerRandomSelection();
            obj.Rock();
            obj.GetResult();
        }

        private void BtnPaper_Click(object sender, RoutedEventArgs e)
        {
            obj.ComputerRandomSelection();
            obj.Paper();
            obj.GetResult();
        }

        private void BtnScissors_Click(object sender, RoutedEventArgs e)
        {
            obj.ComputerRandomSelection();
            obj.Scissors();
            obj.GetResult();
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            obj.ResetData();
        }
    }
}
