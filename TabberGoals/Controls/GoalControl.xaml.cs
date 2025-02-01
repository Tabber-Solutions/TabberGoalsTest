using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace TabberGoals.Controls
{
    /// <summary>
    /// Interaction logic for GoalControl.xaml
    /// </summary>
    public partial class GoalControl : UserControl
    {
        #region Properties
        /// <summary>
        /// The title of the goal
        /// </summary>
        public string? Title
        {
            get { return labelTitle.Content.ToString(); }
            set { labelTitle.Content = value; }
        }

        /// <summary>
        /// The number of targets that the goal contains
        /// </summary>
        public int? Targets
        {
            get { var digits = new string(labelTargets.Content.ToString().Where(char.IsDigit).ToArray()); return int.Parse(digits); }
            set { labelTargets.Content = $"{value} Targets"; }
        }

        /// <summary>
        /// The progress of the goal 
        /// </summary>
        public double Status
        {
            get { return progressBarStatus.Value; }
            set {progressBarStatus.Value = value;}
        }

        /// <summary>
        /// The date that the goal was achieved
        /// </summary>
        public DateTime? DateAchieved
        {
            get { return (DateTime)datePickerDateAchieved.SelectedDate; }
            set { datePickerDateAchieved.SelectedDate = value; }
        }
        #endregion

        public GoalControl()
        {
            InitializeComponent();
        }
    }
}
