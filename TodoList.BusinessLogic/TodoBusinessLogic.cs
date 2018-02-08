using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.DataAccessLayer;

namespace TodoList.BusinessLogic
{
    public class TodoBusinessLogic
    {
        ToDoDataAcces DAL = new ToDoDataAcces();

        /// <summary>
        /// Call GetAllTask method in the DAL
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllTask()
        {            
            try
            {  
                return DAL.GetAllTask();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// Call GetTask method in the DAL
        /// </summary>
        /// <param name="idTask">id of task</param>
        /// <returns></returns>
        public DataTable GetTask(int idTask)
        {
            try
            {
                return DAL.GetTask(idTask);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// Call CreateTask method in the DAL
        /// </summary>
        /// <param name="description">Description of the new task</param>
        /// <returns></returns>
        public string CreateTask(string description)
        {
            try
            {
                return DAL.CreateTask(description);
            }
            catch (Exception exc)
            {
                throw exc;
            }

        }

        /// <summary>
        /// Call EditTask method in the DAL
        /// </summary>
        /// <param name="Id">Id of task</param>
        /// <param name="description">Description of task</param>
        /// <param name="IsDone">state of the task if it is done or not</param>
        /// <returns></returns>
        public string EditTask(int Id, string description, bool IsDone)
        {
            try
            {
                return DAL.EditTask(Id, description, IsDone);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// Call DeleteTask method in the DAL
        /// </summary>
        /// <param name="idTask">Id of task to be eliminate</param>
        /// <returns>an empty string if the result was success, otherwise return an error description</returns>
        public string DeleteTask(int idTask)
        {
            try
            {
                return DAL.DeleteTask(idTask);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            
        }
    }
}
