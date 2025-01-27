using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TabberGoals.Database.DataAccess
{
    public class GoalsDataAccess
    {
        /// <summary>
        /// The connection string to the tabber goals database - needs to be a string read from a file such as reading a string from a .txt file
        /// </summary>
        public SqlConnection connectionString = null;


        /// <summary>
        /// Add goal to database using stored procedure
        /// </summary>
        /// <param name="goalTitle">The title of the goal</param>
        /// <param name="goalStatus">The progress of the goal</param>
        /// <param name="goalDateAchieved">The date when the goal was achieved</param>
        /// <returns>The id of the newly created goal</returns>
        public int AddGoal(string goalTitle, int goalStatus, DateTime goalDateAchieved)
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
                    command.Parameters.AddWithValue("@GoalTitle", goalTitle);
                    command.Parameters.AddWithValue("@GoalStatus", goalStatus);
                    command.Parameters.AddWithValue("@GoalDateAchieved", goalDateAchieved);

                    //Execute command and get goal id
                    int goalID = Convert.ToInt32(command.ExecuteScalar());

                    //Return goal id
                    return goalID;
                }
            }
            catch(Exception ex)
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
        /// Load goals from database using stored procedure 
        /// </summary>
        /// <returns>A table of the loaded goals</returns>
        public DataTable LoadGoals()
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
                using (SqlCommand command = new SqlCommand("LoadGoals", connectionString))
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
        /// Update goal in database using stored procedure 
        /// </summary>
        /// <param name="goalID">The id of the goal</param>
        /// <param name="goalTitle">The title of the goal</param>
        /// <param name="goalStatus">The progress of the goal</param>
        /// <param name="goalDateAchieved">The date when the goal was achieved</param>
        public void UpdateGoal(int goalID, string goalTitle, int goalStatus, DateTime goalDateAchieved)
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
                    command.Parameters.AddWithValue("@GoalID", goalID);
                    command.Parameters.AddWithValue("@GoalTitle", goalTitle);
                    command.Parameters.AddWithValue("@GoalStatus", goalStatus);
                    command.Parameters.AddWithValue("@oalDateAchieved", goalDateAchieved);

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
        /// Delete goal from database using stored procedure
        /// </summary>
        /// <param name="goalID">The id of the goal</param>
        public void DeleteGoal(int goalID)
        {
            try
            {
                //If the connection is not open then make it open
                if (connectionString.State != ConnectionState.Open)
                {
                    connectionString.Open();
                }

                //Creating a new instance of sql command to interact with the stored procedure
                using (SqlCommand command = new SqlCommand("DeleteGoal", connectionString))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    //Add the values for the parameters in the stored procedure
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
    }
}
