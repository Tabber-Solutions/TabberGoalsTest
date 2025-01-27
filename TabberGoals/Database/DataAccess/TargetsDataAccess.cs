using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TabberGoals.Database.DataAccess
{
    public class TargetsDataAccess
    {
        /// <summary>
        /// The connection string to the tabber goals database - needs to be a string read from a file such as reading a string from a .txt file
        /// </summary>
        public SqlConnection connectionString = null;


        /// <summary>
        /// Add target to database using stored procedure
        /// </summary>
        /// <param name="targetTitle">The title of the target</param>
        /// <param name="targetDescription">The description of the target</param>
        /// <param name="targetTimesCompleted">The amount of times the target was completed</param>
        /// <param name="targetToday">Whether the target is added for today</param>
        /// <param name="goalID">The id of the targets associated goal</param>
        /// <returns>The id of the newly created target</returns>
        public int AddTarget(string targetTitle, string targetDescription, int targetTimesCompleted, byte targetToday, int goalID)
        {
            try
            {
                //If the connection is not open then make it open
                if (connectionString.State != ConnectionState.Open)
                {
                    connectionString.Open();
                }

                //Creating a new instance of sql command to interact with the stored procedure and automatically clean code when finished
                using (SqlCommand command = new SqlCommand("AddGoal", connectionString))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    //Add the values for the parameters in the stored procedure
                    command.Parameters.AddWithValue("@TargetTitle", targetTitle);
                    command.Parameters.AddWithValue("@TargetDescription", targetDescription);
                    command.Parameters.AddWithValue("@TargetTimesCompleted", targetTimesCompleted);
                    command.Parameters.AddWithValue("@TargetToday", targetToday);
                    command.Parameters.AddWithValue("@GoalID", goalID);

                    //Execute command and get goal id
                    int targetID = Convert.ToInt32(command.ExecuteScalar());

                    //Return target id
                    return targetID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return -1;
            }
            finally
            {
                //Close the database connection
                connectionString.Close();
            }
        }


        /// <summary>
        /// Load targets from database using stored procedure 
        /// </summary>
        /// <returns>A table of the loaded targets</returns>
        public DataTable LoadTargets()
        {
            //Data table to store vehicles from stored procedure
            DataTable dataTable = new DataTable();

            try
            {
                //If the connection is not open then make it open
                if (connectionString.State != ConnectionState.Open)
                {
                    connectionString.Open();
                }

                //Creating a new instance of sql command to interact with the stored procedure
                using (SqlCommand command = new SqlCommand("LoadTargets", connectionString))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }

                    //Execute command
                    command.ExecuteNonQuery();

                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return dataTable;
            }
            finally
            {
                //Close the database connection
                connectionString.Close();
            }
        }

        /// <summary>
        /// Update target in database using stored procedure 
        /// </summary>
        /// <param name="targetTitle">The title of the target</param>
        /// <param name="targetDescription">The description of the target</param>
        /// <param name="targetTimesCompleted">The amount of times the target was completed</param>
        /// <param name="targetToday">Whether the target is added for today</param>
        /// <param name="goalID">The id of the targets associated goal</param>
        public void UpdateGoal(string targetTitle, string targetDescription, int targetTimesCompleted, byte targetToday, int goalID)
        {
            try
            {
                //If the connection is not open then make it open
                if (connectionString.State != ConnectionState.Open)
                {
                    connectionString.Open();
                }

                //Creating a new instance of sql command to interact with the stored procedure
                using (SqlCommand command = new SqlCommand("UpdateGoal", connectionString))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    //Add the values for the parameters in the stored procedure
                    command.Parameters.AddWithValue("@TargetTitle", targetTitle);
                    command.Parameters.AddWithValue("@TargetDescription", targetDescription);
                    command.Parameters.AddWithValue("@TargetTimesCompleted", targetTimesCompleted);
                    command.Parameters.AddWithValue("@TargetToday", targetToday);
                    command.Parameters.AddWithValue("@GoalID", goalID);

                    //Execute command
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                //Close the database connection
                connectionString.Close();
            }
        }

        /// <summary>
        /// Delete target from database using stored procedure
        /// </summary>
        /// <param name="targetID">The id of the target</param>
        public void DeleteTarget(int targetID)
        {
            try
            {
                //If the connection is not open then make it open
                if (connectionString.State != ConnectionState.Open)
                {
                    connectionString.Open();
                }

                //Creating a new instance of sql command to interact with the stored procedure
                using (SqlCommand command = new SqlCommand("DeleteTarget", connectionString))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    //Add the values for the parameters in the stored procedure
                    command.Parameters.AddWithValue("@TargetID", targetID);

                    //Execute command
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"{ex}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                //Close the database connection
                connectionString.Close();
            }
        }
    }
}
