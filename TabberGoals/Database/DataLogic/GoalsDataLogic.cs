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
    public class GoalsDataLogic
    {
        GoalsDataAccess GoalsDataAccess = new GoalsDataAccess();

        /// <summary>
        /// Add goal to the database and goal grid
        /// </summary>
        public void AddGoal(string title, int status, DateTime dateAchieved, TabberWrapPanel goalArea)
        {
            try
            {
                //Add data to database
                GoalsDataAccess.AddGoal(title, status, dateAchieved);

                //Create goal and add details
                GoalControl goalControl = new GoalControl();
                goalControl.SetTitle(title);
                goalControl.SetStatus(status);
                goalControl.SetDateAchieved(dateAchieved);

                //Add goal to goal area
                goalArea.Children.Add(goalControl);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
