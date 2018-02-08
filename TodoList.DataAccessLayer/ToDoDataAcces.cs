using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using TodoList.DataAccessLayer.Resources;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TodoList.DataAccessLayer
{
    public class ToDoDataAcces
    {
      
        public DataTable GetAllTask()
        {
            try
            {   //Create a new connection and get the connection string
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[Data.ConnectionName].ConnectionString);
                
                SqlCommand cmd = new SqlCommand( Data.QueryAllTask , conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable dtTodo = new DataTable();

                //Validate if the reader has rows
                if (reader.HasRows)
                {                    
                    dtTodo.Load(reader);   //Load DataReader into the DataTable
                }
                
                reader.Close();

                return dtTodo;
            }
            catch (SqlException exc)
            {
                throw exc;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// Get a specific task
        /// </summary>
        /// <param name="idTask">id of task</param>
        /// <returns></returns>
        public DataTable GetTask(int idTask)
        {
            try
            {   //Create a new connection and get the connection string
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[Data.ConnectionName].ConnectionString);

                SqlCommand cmd = new SqlCommand("spGetTask", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Creation of parameters and their properties
                SqlParameter pIdTask = new SqlParameter("@pIdTask", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = idTask
                };

                SqlParameter pMessage = new SqlParameter("@pMessage", SqlDbType.VarChar)
                {
                    Direction = ParameterDirection.Output,
                    Value = string.Empty
                };

                //Adding the parameters to the command
                cmd.Parameters.Add(pIdTask);
                cmd.Parameters.Add(pMessage);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable dtTodo = new DataTable();

                //Validate if the reader has rows
                if (reader.HasRows)
                {
                    dtTodo.Load(reader);   //Load DataReader into the DataTable
                }

                reader.Close();

                return dtTodo;
            }
            catch (SqlException exc)
            {
                throw exc;
            }
            catch (Exception exc)
            {
                throw exc;
            }

        }

        /// <summary>
        /// Create a new Task
        /// </summary>
        /// <param name="description">Description of the task</param>
        /// <returns></returns>
        public string CreateTask(string description)
        {

            try
            {   //Get the connection string and create a new connection 
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[Data.ConnectionName].ConnectionString);

                SqlCommand cmd = new SqlCommand("spCreateTask", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Creation of parameters and their properties
                SqlParameter pTaskDescription = new SqlParameter("@pTaskDescription", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = description
                };

                SqlParameter pMessage = new SqlParameter("@pMessage", SqlDbType.VarChar)
                {
                    Direction = ParameterDirection.Output,
                    Value = string.Empty
                };

                //Adding the parameters to the command
                cmd.Parameters.Add(pTaskDescription);
                cmd.Parameters.Add(pMessage);

                conn.Open();
                cmd.ExecuteNonQuery();

                string message = cmd.Parameters["@pMessage"].Value.ToString();

                return message;
            }
            catch (SqlException exc)
            {
                throw exc;
            }
            catch (Exception exc)
            {
                throw exc;
            }        
        }

        /// <summary>
        /// Edit a specific task
        /// </summary>
        /// <param name="Id">Id of task</param>
        /// <param name="description">Description of task</param>
        /// <param name="IsDone">state of the task if it is done or not</param>
        /// <returns></returns>
        public string EditTask(int Id, string description, bool IsDone)
        {

            try
            {   //Create a new connection and get the connection string
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[Data.ConnectionName].ConnectionString);

                SqlCommand cmd = new SqlCommand("spUpdateTask", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Creation of parameters and their properties
                SqlParameter pIdTask = new SqlParameter("@pIdTask", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = Id
                };

                SqlParameter pTaskDescription = new SqlParameter("@pTaskDescription", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = description
                };

                SqlParameter pIsDone = new SqlParameter("@pIsDone", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Input,
                    Value = IsDone
                };

                SqlParameter pMessage = new SqlParameter("@pMessage", SqlDbType.VarChar)
                {
                    Direction = ParameterDirection.Output,
                    Value = string.Empty
                };

                //Adding the parameters to the command
                cmd.Parameters.Add(pIdTask);
                cmd.Parameters.Add(pTaskDescription);
                cmd.Parameters.Add(pIsDone);
                cmd.Parameters.Add(pMessage);

                conn.Open();
                cmd.ExecuteNonQuery();

                string message = cmd.Parameters["@pMessage"].Value.ToString();

                return message;
            }
            catch (SqlException exc)
            {
                throw exc;
            }
            catch (Exception exc)
            {
                throw exc;
            }

        }

        /// <summary>
        /// Delete a specific task
        /// </summary>
        /// <param name="idTask">Id of task to be eliminate</param>
        /// <returns>an empty string if the result was success, otherwise return an error description</returns>
        public string DeleteTask(int idTask)
        {
            try
            {   //Create a new connection and get the connection string
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[Data.ConnectionName].ConnectionString);

                SqlCommand cmd = new SqlCommand("spDeleteTask", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Creation of parameters and their properties
                SqlParameter pIdTask = new SqlParameter("@pIdTask", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = idTask
                };

                SqlParameter pMessage = new SqlParameter("@pMessage", SqlDbType.VarChar)
                {
                    Direction = ParameterDirection.Output,
                    Value = string.Empty
                };

                //Adding the parameters to the command
                cmd.Parameters.Add(pIdTask);
                cmd.Parameters.Add(pMessage);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                return cmd.Parameters["@pMessage"].Value.ToString();

            }
            catch (SqlException exc)
            {
                throw exc;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
