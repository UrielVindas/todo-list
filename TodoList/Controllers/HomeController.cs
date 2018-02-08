using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoList.Models;
using TodoList.BusinessLogic;
using System.Data;

namespace TodoList.Controllers
{
    public class HomeController : Controller
    {
        TodoBusinessLogic BLL = new TodoBusinessLogic();

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Call the GetAllTask method of the business logic layer
        /// </summary>
        /// <returns>The list of task</returns>
        public ActionResult TodoList()
        {
            DataTable dtAllTask = BLL.GetAllTask();
            List<ToDo> tasks = new List<ToDo>();

            if (dtAllTask != null && dtAllTask.Rows.Count > 0)
            {
                tasks = dtAllTask.AsEnumerable().Select(row => new ToDo
                {
                    Id = row.Field<int>("IdTask"),
                    description = row.Field<string>("TaskDescription"),
                    IsDone = row.Field<bool>("IsDone")
                }).ToList();
            }                       

            return View(tasks);
        }

        /// <summary>
        /// Action to call the CreateTask View
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateTask()
        {
            return View();
        }


        /// <summary>
        /// Action to call the GetTask method of the business logic layer
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult EditTask(int Id)
        {
            DataTable dtTask = BLL.GetTask(Id);
            ToDo tasks = null;

            if (dtTask != null && dtTask.Rows.Count > 0)
            {
                tasks = new ToDo
                {
                    Id = dtTask.Rows[0].Field<int>("IdTask"),
                    description = dtTask.Rows[0].Field<string>("TaskDescription"),
                    IsDone = dtTask.Rows[0].Field<bool>("IsDone")
                };
            }

            return View(tasks);
        }

        /// <summary>
        /// Action to call the CreateTask method of the business logic layer
        /// </summary>
        /// <param name="description">Description of the task</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateTask(string description)
        {
            
            ViewBag.messaje = BLL.CreateTask(description);
            return RedirectToAction("TodoList");
        }

        /// <summary>
        /// Action to call the EditTask method of the business logic layer
        /// </summary>
        /// <param name="Id">Id of the task to be edit</param>
        /// <param name="description">description of the task</param>
        /// <param name="IsDone">Status of the task</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditTask(int Id, string description, bool IsDone)
        {
            ViewBag.messaje = BLL.EditTask(Id, description, IsDone);
            return RedirectToAction("TodoList");
        }

        /// <summary>
        /// Action to call the DeleteTask method of the business logic layer
        /// </summary>
        /// <param name="Id">Id of the task to be eliminate</param>
        /// <returns></returns>
        public ActionResult DeleteTask(int Id)
        {
            ViewBag.messaje = BLL.DeleteTask(Id);
            return RedirectToAction("TodoList");
        }

        /// <summary>
        /// Action to call the EditTask method of the business logic layer,
        /// this action use this method for change the state of one specific task
        /// </summary>
        /// <param name="Id">Id of the task to be edit</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DoneTask(int Id)
        {
            string messaje = BLL.EditTask(Id, string.Empty, true);
            return Json(new
            {
                msg = messaje
            });
        }
    }
}