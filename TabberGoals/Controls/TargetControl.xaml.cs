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
    /// Interaction logic for TargetControl.xaml
    /// </summary>
    public partial class TargetControl : UserControl
    {
        #region Properties
        /// <summary>
        /// The title of the target
        /// </summary>
        public string? Title { get; private set; }

        /// <summary>
        /// The description of target
        /// </summary>
        public string? Descripion {  get; private set; }

        /// <summary>
        /// The progress of the target 
        /// </summary>
        public int TimesCompleted { get; private set; }

        /// <summary>
        /// is target being done today
        /// </summary>
        public byte Today { get; private set; }

        /// <summary>
        /// The ID of the parent goal
        /// </summary>
        public int GoalID { get; private set; }
        #endregion

        public TargetControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Set title property
        /// </summary>
        /// <param name="title">The title of the target</param>
        public void SetTitle(string title)
        {
            try
            {
                //If title is null then mnake it default
                if(string.IsNullOrEmpty(title))
                {
                    title = "Target Title";
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
        /// Set description property
        /// </summary>
        /// <param name="description">The description of the target</param>
        public void SetDescription(string description)
        {
            try
            {
                //If description is null then mnake it default
                if (string.IsNullOrEmpty(description))
                {
                    description = "Target Title";
                }

                //Set value of description property
                Descripion = description;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Set times completed property
        /// </summary>
        /// <param name="timesCompleted">The status of the target</param>
        public void SetTimesCompleted(int timesCompleted)
        {
            try
            {
                //Set value of times completed property
                TimesCompleted = timesCompleted;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Set today property
        /// </summary>
        /// <param name="today">If target is being done today</param>
        public void SetToday(byte today)
        {
            try
            {
                //Set value of today property
                Today = today;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Set goalId property
        /// </summary>
        /// <param name="goalID">The ID of the parent goay</param>
        public void SetGoalID(int goalID)
        {
            try
            {
                //Set value of goalId property
                GoalID = goalID;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
