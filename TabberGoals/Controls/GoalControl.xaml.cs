using Microsoft.Win32;
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
        public string? Title { get; private set; }

        /// <summary>
        /// The number of targets that the goal contains
        /// </summary>
        public int? Targets {  get; private set; }

        /// <summary>
        /// The progress of the goal 
        /// </summary>
        public double Status { get; private set; }

        /// <summary>
        /// The date that the goal was achieved
        /// </summary>
        public DateTime? DateAchieved { get; private set; }
        #endregion

        public GoalControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Set title property
        /// </summary>
        /// <param name="title">The title of the goal</param>
        public void SetTitle(string title)
        {
            try
            {
                //If title is null then mnake it default
                if(string.IsNullOrEmpty(title))
                {
                    title = "Goal Title";
                }

                //Set value of title property
                Title = title;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Set status property
        /// </summary>
        /// <param name="status">The status of the goal</param>
        public void SetStatus(int status)
        {
            try
            {
                //Set value of status property
                Status = status;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Set date achieved property
        /// </summary>
        /// <param name="dateAchieved">The date the goal was achieved</param>
        public void SetDateAchieved(DateTime dateAchieved)
        {
            try
            {
                //Set value of date achieved property
                DateAchieved = dateAchieved;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
