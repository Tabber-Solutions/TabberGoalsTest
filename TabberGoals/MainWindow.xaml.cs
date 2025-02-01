using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TabberGoals.Controls;

namespace TabberGoals
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            GoalControl goalControl = new GoalControl();
            goalControl.Title = "Test";
            goalControl.Targets = 2;
            goalControl.Status = 73.8;
            goalControl.DateAchieved = DateTime.Today;

            Grid.Children.Add(goalControl);

            MessageBox.Show(goalControl.Targets.ToString());
        }
    }
}