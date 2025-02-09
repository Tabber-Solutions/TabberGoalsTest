using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TabberGoals.TabberUI.Controls;
using TabberGoals.Controls;
using TabberGoals.Database.DataAccess;

namespace TabberGoals.Database.DataLogic
{
    public class TargetsDataLogic
    {
        TargetsDataAccess TargetsDataAccess = new TargetsDataAccess();

        /// <summary>
        /// Add target to the database and target grid
        /// </summary>
        public void AddGoal(string title, string description, int timesCompleted, byte targetToday, int goalId, TabberWrapPanel targetArea)
        {
            try
            {
                //Add data to database
                TargetsDataAccess.AddTarget(title, description, timesCompleted, targetToday, goalId);

                //Create target and add details
                TargetControl targetControl = new TargetControl();
                targetControl.SetTitle(title);
                targetControl.SetDescription(description);
                targetControl.SetTimesCompleted(timesCompleted);
                targetControl.SetToday(targetToday);
                targetControl.SetGoalID(goalId);

                //Add target to target area
                targetArea.Children.Add(targetControl);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
