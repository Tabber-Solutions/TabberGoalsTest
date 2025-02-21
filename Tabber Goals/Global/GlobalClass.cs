using System;
using System.Collections.Generic;
// TODO Although ClickOnce is supported on .NET 5+, apps do not have access to the System.Deployment.Application namespace. For more details see https://github.com/dotnet/deployment-tools/issues/27 and https://github.com/dotnet/deployment-tools/issues/53.
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Tabber_Goals.Component;
using Tabber_Goals.Database;
using Tabber_Goals.TabberUI.Controls;

namespace Tabber_Goals.Global
{
    public static class GlobalClass
    {
        //This class contains methods that
        //don't fit in other classes or event
        //classes eg. GoalControlEventsClass.cs
        //or are needing to be used by multiple classes.

        #region Classes
        static DatabaseAccessClass DatabaseAccessClass = new DatabaseAccessClass();
        #endregion

        #region Goal Sizes
        public static void GoalSizes(TabberWrapPanel GoalArea, GoalControl GoalControl)
        {
            GoalControl.Width = GoalArea.ActualWidth / 5 - 20;
            GoalControl.Height = 200;
            GoalControl.Margin = new Thickness(10);

            GoalControl.MinWidth = 200;
            GoalControl.MinHeight = 200;
        }
        #endregion

        #region Goal Count
        public static int MaximumGoalCount()
        {
            return 15;
        }

        public static string GoalCountLabelText(TextBlock GoalCountLabel)
        {
            return GoalCountLabel.Text = $"Goals Created {DatabaseAccessClass.GoalCount()}/{MaximumGoalCount()}";
        }
        #endregion

    }
}
